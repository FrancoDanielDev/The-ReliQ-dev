using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco
public class BulletAttackHitbox : DealsDamage
{
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (!other.GetComponent<Sentry>() && (other.CompareTag("Terrain") || other.GetComponent<Entity>()))
        {
            Destroy(gameObject);
        }
    }
}
