using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        animator.Play("Idle");
    }

    public void PlayStartAttack()
    {
        // For player: dodge the attack
        // From IdleAttack or Idle to Start Attack
        animator.SetTrigger("StartAttack");
    }
    public void PlayEndAttack()
    {
        // Attack after dodging the boss.
        // Since the "time" will be frozen at the end of StartAttack Animation, this one is going to "REStart" the time flow.
        animator.SetTrigger("EndAttack");
    }

    public void PlayDamaged()
    {
        // Once it takes damage.
        animator.SetTrigger("Damaged");
    }

    public void PlayDefeated()
    {
        // Once it takes damage.
        animator.SetTrigger("Defeated");
    }
}