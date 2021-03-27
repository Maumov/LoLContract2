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

    
    [Header("Boss Combat Values Attack 1")]
    public int damage;
    public float timeBetweenAttacks;
    float nextAttack;
    public TimerViewer timerViewer;
    [Header("Boss Combat Values Attack 2")]
    public int damage2;
    public float timeBetweenAttacks2;
    float nextAttack2;
    //public TimerViewer timerViewer2;

    bool isAttack1;
    bool isCurrentAttack1;
    string actionToDo;

    private void Start(){
        stats = GetComponent<Stats>();
        stats.OnDamageReceived += DamageReceived;
        questionHandler = FindObjectOfType<QuestionHandler>();
        nextAttack = Time.time + timeBetweenAttacks;
        nextAttack2 = Time.time + timeBetweenAttacks2;
        animator = GetComponent<AnimatorController>();
        if (isPlayer){
            questionHandler.OnCorrect += Attack;
        }else{
            timerViewer = FindObjectOfType<TimerViewer>();
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
            if(IsPlayer()) {
                if(actionToDo == "Attack") {
                    StartCoroutine(animator.Attack());
                }
                if(actionToDo == "Curarse") {
                    StartCoroutine(animator.Heal());
                }
                if(actionToDo == "Escudo") {
                    StartCoroutine(animator.Defend());
                }
            } else {
                StartCoroutine(animator.Attack());
            }
        }
    }

    void DamageReceived() {
        nextAttack = Time.time + timeBetweenAttacks;
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
        if(isPlayer) {
            target.GetDamage(damage);
        } else {
            if(isCurrentAttack1) {
                target.GetDamage(damage);
            } else {
                target.GetDamage(damage2);
            }
        }
    }

    #endregion


    IEnumerator BossCombat() {

        Debug.Log("Boss Combat start");
        //yield return new WaitForSeconds(4f);

        while(!stats.isDead()) {

            if(target != null) {
                if(target.GetComponent<Stats>().isDead()) {
                    nextAttack = Time.time + timeBetweenAttacks;
                    //nextAttack2 = Time.time + timeBetweenAttacks2;
                    yield return null;
                }
            }

            if(TutorialViewer.isShowing) {
                nextAttack += Time.deltaTime;
                //nextAttack2 += Time.deltaTime;
            } else {
                float val1 = (nextAttack - Time.time) / timeBetweenAttacks;
                //float val2 = (nextAttack2 - Time.time) / timeBetweenAttacks2;
                timerViewer.UpdateValue( val1);
            }

            if(nextAttack < Time.time) {
                isAttack1 = true;
                yield return StartCoroutine(WaitAttackTurn());
            }
            //if(nextAttack2 < Time.time) {
            //    isAttack1 = false;
            //    yield return StartCoroutine(WaitAttackTurn());
            //}
            yield return null;

        }

        Debug.Log("Boss Combat end");
        yield return null;
    }

    [ContextMenu("Atacar")]
    void TestAtacar() {
        damage = 1000;
        damage2 = 1000;
        Attack("Attack");
    }

    [ContextMenu("Curarse")]
    void TestHeal() {
        Attack("Curarse");
    }

    public void Attack(string accion) {
        actionToDo = accion;
        if(stats.isDead()) {
            stats.Revive();
        } else {
            isCurrentAttack1 = true;
            StartCoroutine(WaitAttackTurn());
        }
    }

    IEnumerator WaitAttackTurn() {
        while(!canAttack) {
            yield return null;
        }
        InitAttack();
        if(isAttack1) {
            isCurrentAttack1 = true;
            nextAttack = Time.time + timeBetweenAttacks;
        } 
        //else {
            //isCurrentAttack1 = false;
            //nextAttack2 = Time.time + timeBetweenAttacks2;
        //}
        
    }

    public void GetDamage(float value) {
        stats.GetDamage(value);
    }

}