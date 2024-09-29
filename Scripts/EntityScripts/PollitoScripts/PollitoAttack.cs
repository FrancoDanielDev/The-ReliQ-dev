using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco
public class PollitoAttack : DealsDamage
{
    [SerializeField] private Pollito _pollitoScript;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            base.OnTriggerEnter(other);

            _pollitoScript.Boom();
        }
        
    }
}
