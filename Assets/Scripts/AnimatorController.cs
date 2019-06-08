using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    Stats stats;

    private void Start(){
        animator = GetComponent<Animator>();
        stats = GetComponent<Stats>();
        stats.OnDamageReceived += PlayDamaged;
        stats.OnDead += Dead;
    }

    public void Attack(){
        animator.SetTrigger("Attack");
    }

    public void PlayRandomAnimation(){
        //animator.SetInteger("DodgeRandom", Random.Range(0, 4));
        animator.SetInteger("AttackRandom", Random.Range(0, 2));
        animator.SetInteger("ReturnRandom", Random.Range(0, 2));
    }
    
    public void PlayDamaged(){
        animator.SetTrigger("GetHit");
    }

    public void Dead() {
        animator.SetTrigger("Death");
    }
    
}