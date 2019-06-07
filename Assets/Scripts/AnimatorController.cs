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
        
    }
    

    public void PlayDamaged(){
        animator.SetTrigger("Damaged");
    }

    public void Dead() {
        animator.SetTrigger("Dead");
    }
}