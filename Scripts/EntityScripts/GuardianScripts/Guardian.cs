using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco
public class Guardian : Entity, IDamageable
{
    [Header("GUARDIAN STATS")]
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _visionRadiusObj;
    [SerializeField] private GameObject _attackRadiusObj;
    [SerializeField] private GameObject _attackHitboxObj;
    [SerializeField] private CapsuleCollider _capsuleCollider;

    [SerializeField] private GameObject _potis;

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

        if (life <= 0)
        {
            if (Random.Range(0f, 50f) >= 30f)
            {
                Instantiate(_potis, transform.position, transform.rotation);
            }

            Destroy(_visionRadiusObj);
            Destroy(_attackRadiusObj);
            Destroy(_attackHitboxObj);
            Destroy(_capsuleCollider);

            _animator.SetTrigger("Death");
        }
    }
}
