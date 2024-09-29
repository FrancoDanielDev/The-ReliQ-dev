using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco
public class Sentry : Entity, IDamageable
{
    [Header ("SENTRY STATS")]
    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _sentryDelayRotation;

    [Header ("BULLET STATS")]
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletTimeDuration;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint;

    private float _time;
    private Rigidbody _shoot;

    public void Shoot()
    {
        _time += Time.deltaTime;

        if (_time >= _attackCooldown)
        {
            _time = 0;
            _shoot = Instantiate(_bullet.GetComponent<Rigidbody>(), _shootPoint.position, transform.rotation);
            _shoot.AddForce(transform.forward * _bulletSpeed);
            AudioManager.instance.Play("RangeAttacking");
            Destroy(_shoot.gameObject, _bulletTimeDuration);
        }       
    }

    public void LookAt()
    {
        var lookPos = GameObject.FindWithTag("Player").transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _sentryDelayRotation);
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
    }
}
