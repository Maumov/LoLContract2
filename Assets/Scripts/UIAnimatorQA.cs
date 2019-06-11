using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimatorQA : MonoBehaviour
{
    Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
        Combat[] combats = FindObjectsOfType<Combat>();

        foreach (Combat c in combats){
            c.OnStartAttack += HideUI;
            c.OnReturnToPosition += ShowUI;
        }
    }

    void HideUI(){
        if (!animator.GetBool("IsHiden")){
            animator.SetBool("IsHiden", true);
        }
    }
    void ShowUI(){
        if (animator.GetBool("IsHiden"))
        {
            animator.SetBool("IsHiden", false);
        }
    }
}