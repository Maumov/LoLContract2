using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatorController))]
public class Combat : MonoBehaviour
{
    public bool isPlayer;
    public AnimatorController animator;
    public QuestionHandler questionHandler;
    bool isAttacking;

    public delegate void combatDelegate();
    public event combatDelegate OnStartAttack, OnArriveOnTarget, OnStartSlash, OnFinishSlash, OnReturnToPosition;

    private void Start(){
        OnStartAttack += AttackWasTrigger;
        OnReturnToPosition += AttackCompleted;
        animator = GetComponent<AnimatorController>();
        if (isPlayer){
            //questionHandler.OnCorrect += InitAttack;
        }
        else{
            //questionHandler.OnWrong += InitAttack;
        }
    }

    public bool IsPlayer()
    {
        return isPlayer;
    }

    public bool IsAttacking(){
        return isAttacking;
    }

    public bool InitAttack(){
        if (!isAttacking){
            StartCoroutine(animator.Attack());
            return true;
        }
        else {
            return false;
        }
    }

    // Delegates triggers
    #region 

    public void StartAttack()
    {
        if (OnStartAttack != null)
        {
            OnStartAttack.Invoke();
        }
    }

    public void ArriveOnTarget()
    {
        if (OnArriveOnTarget != null)
        {
            OnArriveOnTarget.Invoke();
        }
    }

    public void StartSlash()
    {
        if (OnStartSlash != null)
        {
            OnStartSlash.Invoke();
        }
    }

    public void FinishSlash()
    {
        if (OnFinishSlash != null)
        {
            OnFinishSlash.Invoke();
        }
    }

    public void ReturnToPosition()
    {
        if (OnReturnToPosition != null)
        {
            OnReturnToPosition.Invoke();
        }
    }

    #endregion

    void AttackWasTrigger(){
        isAttacking = true;
    }

    void AttackCompleted(){
        isAttacking = false;
    }
}