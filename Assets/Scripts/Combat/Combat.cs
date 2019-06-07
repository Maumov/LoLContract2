using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatorController))]
public class Combat : MonoBehaviour
{
    public bool isPlayer;
    public AnimatorController animator;
    public QuestionHandler questionHandler;

    delegate void combatDelegate();
    event combatDelegate OnStartAttack, OnArriveOnTarget, OnStartSlash, OnFinishSlash, OnReturnToPosition;

    private void Start(){
        animator = GetComponent<AnimatorController>();
        if (isPlayer){
            questionHandler.OnCorrect += InitAttack;
        }
        else{
            questionHandler.OnWrong += InitAttack;
        }
    }

    public void InitAttack(){
        if (isPlayer)
        {
            animator.PlayRandomAnimation();
            animator.Attack();
        }
    }

    public void StartAttack(){
        if(OnStartAttack != null)
        {
            OnStartAttack.Invoke();
        }
    }

    public void ArriveOnTarget(){
        if (OnArriveOnTarget != null)
        {
            OnArriveOnTarget.Invoke();
        }
    }

    public void StartSlash(){
        if (OnStartSlash != null)
        {
            OnStartSlash.Invoke();
        }
    }

    public void FinishSlash(){
        if (OnFinishSlash != null)
        {
            OnFinishSlash.Invoke();
        }
    }

    public void ReturnToPosition(){
        if (OnReturnToPosition != null)
        {
            OnReturnToPosition.Invoke();
        }
    }
}