using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    Stats stats;
    Combat combat;
    public GameObject weapon;
    public Transform target;
    public float delayAnimation = 0.2f;
    public float movementDuration;
    public float returnDuration;

    Vector3 defaultLocation;

    public delegate void movementAnimations();
    public event movementAnimations OnStep, OnLand;

    private void Start(){
        defaultLocation = transform.position;
        animator = GetComponent<Animator>();
        stats = GetComponent<Stats>();
        combat = GetComponent<Combat>();
        stats.OnDamageReceived += PlayDamaged;
        stats.OnDead += Dead;

        OnStep += FootL;
        OnStep += FootR;
        OnLand += Land;
    }
    
    // No deja realizarlo en la misma animacion.
    public void ActivateWeapon(){
        if(weapon != null){
            weapon.SetActive(true);
        }
    }

    [ContextMenu("StartAttack")]
    public void PlayAttack(){
        StartCoroutine(Attack());
    }

    [ContextMenu("GetHit")]
    public void PlayDamaged(){
        animator.SetTrigger("GetHit");
    }

    [ContextMenu("PlayDeath")]
    public void PlayDeath(){
        animator.SetBool("Death", true);
        PlayDamaged();
    }

    public void Dead() {
        animator.SetBool("Death", true);
    }

    void Hit(){
        combat.FinishSlash();
    }

    void FootL(){

    }

    void FootR(){

    }

    void Land(){

    }

    public IEnumerator Attack(){

        animator.SetTrigger("IniatiateCombat");
        combat.StartAttack();

        yield return new WaitForSeconds(delayAnimation);

        float lerpTime = 0;
        while (lerpTime < 1)
        {
            lerpTime += Time.deltaTime * (1 / movementDuration);
            transform.position = Vector3.Lerp(defaultLocation, target.position, lerpTime);
            yield return new WaitForEndOfFrame();
        }

        animator.SetTrigger("Attack");
        combat.ArriveOnTarget();

        bool startAnimationAttack = false;
        while (!startAnimationAttack){
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
                startAnimationAttack = true;
            }
            else{
                yield return new WaitForEndOfFrame();
            }
        }
        combat.StartSlash();
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1){
            yield return new WaitForEndOfFrame();
        }
        animator.SetTrigger("ReturnPosition");

        yield return new WaitForSeconds(delayAnimation);

        lerpTime = 0;
        while (lerpTime < 1)
        {
            lerpTime += Time.deltaTime * (1 / returnDuration);
            transform.position = Vector3.Lerp(target.position, defaultLocation, lerpTime);
            yield return new WaitForEndOfFrame();
        }

        combat.ReturnToPosition();
        animator.SetTrigger("Completed");
    }
}