using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Franco & Bortoló
public class Player : Entity, IDamageable
{
    [Header ("PLAYER STATS")]
    public float playerSpeed, dashCooldown, dashSpeed, dashTime, invulnerableTime;
    public bool canMove = true;

    [Header ("DRAGGABLE VARIABLES")]
    public Transform charCam;
    public Rigidbody myRigidbody;
    public PlayerMovement movement;
    public Animator animator;
    public ParticleSystem dashParticle;
    public ParticleSystem shieldParticle;
    public ParticleSystem healingParticle;

    [HideInInspector] public Vector3 moveDir;

    private PlayerControl _control;
    private PlayerAttack _attack;
    private PlayerDash _dash;

    public EnemySpawner currentSpawner;

    private bool _dying = false;
    [HideInInspector] public bool _invulnerability = false;

    // Bortoló
    private void Awake()
    {
        movement = new PlayerMovement(transform, moveDir, myRigidbody, playerSpeed);
        _attack = new PlayerAttack(animator);
        _dash = new PlayerDash(dashSpeed, dashTime, transform, myRigidbody, dashParticle);
        _control = new PlayerControl(movement, _attack, _dash, animator, charCam, this);
    }

    void Update()
    {
        if (canMove)
        {
            _control.ArtificialUpdate();
        }

        shieldParticle.transform.rotation = new Quaternion(145, 0, 0, 0);
    }

    // Franco & Bortoló
    public void ReceiveDamage(int dmg)
    {
        if (_dying == false && _invulnerability == false)
        {
            life -= dmg;
            CameraShake.instance.ShakeCamera();
            AudioManager.instance.Play(hurtAudio);

            if (life <= 0)
            {
                StartCoroutine(Die());
            }
            else
            {
                _hurtParticle.Play();
                StartCoroutine(Invulnerability());
            }

            UIManager.instance.HealthUpdate(life);
        }      
    }

    private IEnumerator Invulnerability()
    {
        _invulnerability = true;
        shieldParticle.Play();

        yield return new WaitForSeconds(invulnerableTime);

        _invulnerability = false;
    }

    public void Revive()
    {
        life = 3;
        canMove = true;
        _dying = false;
        UIManager.instance.HealthUpdate(life);

        animator.Play("Idle");
    }

    // Bortoló
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndingSequence"))
        {
            other.GetComponent<EndSequence>().StartEnding();
        }

        if (other.CompareTag("EnemySpawner"))
        {
            currentSpawner = other.GetComponent<EnemySpawner>();
        }
    }

    private IEnumerator Die()
    {
        _dying = true;
        AudioManager.instance.Play(deathAudio);
        _finalHitParticle.Play();
        animator.Play("DeathAnim");
        canMove = false;

        yield return new WaitForSeconds(3);

        if(currentSpawner != null)
        {
            currentSpawner.Despawn();
        }

        GameManager.instance.Loss();
    }
}
