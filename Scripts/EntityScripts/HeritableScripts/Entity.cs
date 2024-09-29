using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco
public abstract class Entity : MonoBehaviour
{
    [Header ("BASIC ENTITY STATS")]
    public int life;
    [SerializeField] protected string hurtAudio;
    [SerializeField] protected string deathAudio;
    [SerializeField] protected float _deathCooldown = 0.000000001f;
    [SerializeField] protected ParticleSystem _hurtParticle;
    [SerializeField] protected ParticleSystem _finalHitParticle;
}
