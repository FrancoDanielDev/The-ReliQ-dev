using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco - Bortoló
public class PlayerDash
{
    private float _dashSpeed, _dashTime;
    private Transform _playerTransform;
    private Rigidbody _playerRigidbody;
    private ParticleSystem _dashParticle;

    public PlayerDash(float ds, float dt, Transform t, Rigidbody rb, ParticleSystem dp)
    {
        _dashTime = dt;
        _dashSpeed = ds;
        _playerTransform = t;
        _playerRigidbody = rb;
        _dashParticle = dp;
    }

    public IEnumerator Dash()
    {
        float startTime = Time.time;
        _dashParticle.Play();
        AudioManager.instance.Play("PlayerDash");
    
        while (Time.time < startTime + _dashTime)
        {
            _playerRigidbody.AddForce(_playerTransform.forward * _dashSpeed, ForceMode.Impulse);

            _playerRigidbody.constraints = RigidbodyConstraints.FreezePositionY;

            yield return null;
        }
    
        yield return new WaitForSeconds(.2f);

        _playerRigidbody.constraints = ~RigidbodyConstraints.FreezePosition;

        _dashParticle.Stop();
    }
}
