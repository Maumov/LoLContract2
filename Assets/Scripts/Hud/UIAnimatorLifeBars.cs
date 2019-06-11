using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimatorLifeBars : MonoBehaviour
{
    Animator animator;
    public bool isPlayerUI;

    private void Start(){
        animator = GetComponent<Animator>();
        Combat[] combats = FindObjectsOfType<Combat>();
        
        foreach (Combat c in combats){
            c.OnReady += StartUI;
            if (c.isPlayer == isPlayerUI){
                c.OnReady += StartUI;
                c.GetComponent<Stats>().OnDamageReceived += Shake;
            }
        }
    }

    void Shake(){
        animator.SetTrigger("Shake");
    }

    void StartUI(){
        animator.SetTrigger("Start");
    }
}