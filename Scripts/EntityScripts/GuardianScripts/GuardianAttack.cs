using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco
public class GuardianAttack : MonoBehaviour
{
    [HideInInspector] public bool playSound, stopAttacking;

    [SerializeField] private GuardianVisionRange _visionScript;
    [SerializeField] private float _cooldown;
    [SerializeField] private Animator _animator;
    [SerializeField] private SphereCollider _attackCollider;

    private float _time;

    public delegate void MyDelegate();
    public MyDelegate attackDelegate = delegate { };

    private void Start()
    {
        _time = _cooldown;
    }

    private void Update()
    {
        attackDelegate();

        _time += Time.deltaTime;

        if (_time >= _cooldown)
        {
            _attackCollider.enabled = true;
        }         
    }

    private void Attack()
    {
        _attackCollider.enabled = false;

        _visionScript.followDelegate = delegate { };
        _visionScript.StopFollowing();

        _time = 0;

        if (playSound)
        {
            AudioManager.instance.Play("GuardianAttacking");
        }

        if (stopAttacking)
        {
            _visionScript.followDelegate = delegate { };
            StopAttacking();           
        }
    }

    public void StopAttacking()
    {
        attackDelegate = delegate { };
        _visionScript.followDelegate = _visionScript.Follow;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _time >= _cooldown)
        {
            attackDelegate = Attack;

            _animator.SetTrigger("Attacking");
        }
    }
}
