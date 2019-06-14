using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatorController))]
public class Combat : MonoBehaviour
{
    public static bool canAttack = true;

    public bool isPlayer;
    AnimatorController animator;
    QuestionHandler questionHandler;
    bool isAttacking;

    public delegate void combatDelegate();
    public event combatDelegate OnReady, OnStartAttack, OnArriveOnTarget, OnStartSlash, OnFinishSlash, OnReturnToPosition;

    Combat target;
    Stats stats;

    public int damage;
    [Header("Boss Combat Values")]
    public float timeBetweenAttacks;
    float nextAttack;

    private void Start(){
        stats = GetComponent<Stats>();
        stats.OnDamageReceived += DamageReceived;
        questionHandler = FindObjectOfType<QuestionHandler>();
        nextAttack = Time.time;
        
        animator = GetComponent<AnimatorController>();
        if (isPlayer){
            questionHandler.OnCorrect += Attack;
        }else{

            StartCoroutine(BossCombat());
    
        }
    }

    public bool IsPlayer()
    {
        return isPlayer;
    }
    
    public void InitAttack(){
        if(!isAttacking) {
            isAttacking = true;
            canAttack = false;
            StartCoroutine(animator.Attack());
        }
    }

    void DamageReceived() {
        nextAttack += timeBetweenAttacks;
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

    public void ReturnToPosition()
    {
        if (OnReturnToPosition != null)
        {
            OnReturnToPosition.Invoke();
        }
        isAttacking = false;
        canAttack = true;
    }

    public void IntroReady()
    {
        if (OnReady != null)
        {
            OnReady.Invoke();
        }
    }

    void Hit()
    {
        if (OnFinishSlash != null)
        {
            OnFinishSlash.Invoke();
        }
        if(target == null) {
            Combat[] combats = FindObjectsOfType<Combat>();
            foreach(Combat c in combats) {
                if(c.isPlayer != isPlayer) {
                    target = c;
                }
            }
        }
        target.GetDamage(damage);
    }

    #endregion



    IEnumerator BossCombat() {
        Debug.Log("Boss Combat start");
        yield return new WaitForSeconds(4f);
        while(!stats.isDead()) {

            if(target != null) {
                if(target.GetComponent<Stats>().isDead()) {
                    nextAttack = Time.time + timeBetweenAttacks;
                    yield return null;
                }
            }
            if(nextAttack < Time.time) {
                yield return StartCoroutine(WaitAttackTurn());
            }
            yield return null;
        }
        Debug.Log("Boss Combat end");
        yield return null;
    }

    public void Attack() {
        if(stats.isDead()) {
            stats.Revive();
        } else {
            StartCoroutine(WaitAttackTurn());
        }
    }

    IEnumerator WaitAttackTurn() {
        while(!canAttack) {
            yield return null;
        }
        InitAttack();
        nextAttack = Time.time + timeBetweenAttacks;
    }

    public void GetDamage(float value) {
        stats.GetDamage(value);
    }
}