using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Franco
public class Pollito : Entity, IDamageable
{
    [Header("POLLITO STATS")]
    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private ParticleSystem _trailParticle;
    [SerializeField] private NavMeshAgent _pollito;
    [SerializeField] private float _knockbackStrength;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _player;

    private void Awake()
    {
        _pollito.isStopped = true;
    }

    private void Update()
    {
        _pollito.SetDestination(GameObject.FindWithTag("Player").transform.position);

        if (life <= 0 || _pollito.isStopped)
        {
            AudioManager.instance.Stop("PollitoRunning");
        }
    }   

    public void Follow()
    {
        _pollito.isStopped = false;
        _trailParticle.Play();

        if (life > 0)
        {
            AudioManager.instance.Play("PollitoRunning");
        }      
    }
    
    public void Boom()
    {
        AudioManager.instance.Play("PollitoExplosion");

        _explosionParticle.transform.parent = null;
        _explosionParticle.Play();
        AudioManager.instance.Stop("PollitoRunning");

        gameObject.SetActive(false);
    }

    // Franco & Bortoló
    public void ReceiveDamage(int dmg)
    {
        life -= dmg;

        AudioManager.instance.Play(hurtAudio);

        if (life <= 0)
        {
            AudioManager.instance.Play(deathAudio);

            _finalHitParticle.Play();

            Destroy(gameObject, _deathCooldown);
        }
        else
        {
            _hurtParticle.Play();
        }

        if (life >= 1)
        {
            StartCoroutine(Knockback());
        }
    }
    
    private IEnumerator Knockback()
    {
        _pollito.isStopped = true;
        
        Vector3 direction = _player.transform.position - transform.position;
        direction.y = 0;

        _rb.AddForce(-transform.forward * _knockbackStrength, ForceMode.Impulse);
        
        yield return new WaitForSeconds(.22f);

        _rb.velocity = Vector3.zero;

        yield return new WaitForSeconds(.11f);

        _pollito.isStopped = false;

        yield return null;
    }
}
