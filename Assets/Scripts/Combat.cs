using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatorController))]
public class Combat : MonoBehaviour
{
    public bool isPlayer;
    public AnimatorController animator;

    /*
    public void InitiateAttack()
    {
        if (isPlayer)
        {
            animator.PlayIdle();
        }
        else
        {
            animator.PlayStartAttack();
        }
    }
    */

    public virtual void CorrectAnswer()
    {
        /*
        if (isPlayer)
        {
            animator.PlayStartAttack();
        }
        animator.PlayEndAttack();
        */
    }


    public virtual void WrongAnswer()
    {
        /*
        if(isPlayer == false)
        {
            animator.PlayEndAttack();
        }
        */
    }

    // Se llama cuando la animacion muestra el impacto.
    public virtual void ApplyDamage()
    {
        // Waiting for script
        Debug.Log("Applied");
    }

    void Attack() {

    }
}