using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bortoló
public class PlayerAttack
{
    private Animator _anim;

    public PlayerAttack(Animator a)
    {
        _anim = a;
    }

    public void Attack()
    {
        _anim.SetTrigger("Attacking");
        AudioManager.instance.Play("ProtAttacking");
    }
}
