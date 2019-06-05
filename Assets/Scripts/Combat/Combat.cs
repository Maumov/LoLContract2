using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatorController))]
public class Combat : MonoBehaviour
{
    public bool isPlayer;
    public AnimatorController animator;

    public delegate void AttackEvent();
    public event AttackEvent OnAttack;



    private void Start()
    {
        OnAttack += ApplyDamage;
    }
    

    public virtual void CorrectAnswer()
    {
    }


    public virtual void WrongAnswer()
    {
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