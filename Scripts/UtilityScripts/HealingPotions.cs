using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotions : MonoBehaviour
{
    private Player _methods;
    private Entity _stats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _stats = other.GetComponent<Entity>();
            _methods = other.GetComponent<Player>();

            if(_stats.life < 3 && _stats.life > 0)
            {
                _stats.life++;
                _methods.healingParticle.Play();
                Destroy(gameObject);
                AudioManager.instance.Play("PotionHeal");
                UIManager.instance.HealthUpdate(_stats.life);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
}
