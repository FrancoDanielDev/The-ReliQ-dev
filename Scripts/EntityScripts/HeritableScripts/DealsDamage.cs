using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco & Bortoló
public abstract class DealsDamage : MonoBehaviour
{
    [SerializeField] protected int _damage = 1;

    [SerializeField] protected string _dealsDamageTo = "Player";

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_dealsDamageTo))
        {
            other.GetComponent<IDamageable>().ReceiveDamage(_damage);
        }
    }
}
