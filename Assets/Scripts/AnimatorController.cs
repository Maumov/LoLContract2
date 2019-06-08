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
    public float radiusStopMoving;
    public float movementSpeed;
    public float returnSpeed;
    Vector3 defaultLocation;



    private void Start(){
        defaultLocation = transform.position;
        animator = GetComponent<Animator>();
        stats = GetComponent<Stats>();
        combat = GetComponent<Combat>();
        stats.OnDamageReceived += PlayDamaged;
        stats.OnDead += Dead;
    }
    
    // No deja realizarlo en la misma animacion.
    public void ActivateWeapon()
    {
        if(weapon != null)
        {
            weapon.SetActive(true);
        }
    }

    [ContextMenu("StartAttack")]
    public void PlayAttack()
    {
        StartCoroutine(Attack());
    }

    [ContextMenu("GetHit")]
    public void PlayDamaged(){
        animator.SetTrigger("GetHit");
    }

    [ContextMenu("PlayDeath")]
    public void PlayDeath()
    {
        animator.SetBool("Death", true);
        PlayDamaged();
    }

    public void Dead() {
        animator.SetBool("Death", true);
    }

    public IEnumerator Attack()
    {
        animator.SetTrigger("IniatiateCombat");
        combat.StartAttack();

        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            yield return new WaitForEndOfFrame();
        }

        while (Vector3.Distance(transform.position, target.position) > radiusStopMoving){
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        combat.ArriveOnTarget();
        animator.SetTrigger("Attack");

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

        while (animator.GetCurrentAnimatorStateInfo(0).IsName("ReturnPosition"))
        {
            yield return new WaitForEndOfFrame();
        }

        while (Vector3.Distance(transform.position, defaultLocation) > radiusStopMoving){
            transform.position -= transform.forward * returnSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        combat.ReturnToPosition();
        animator.SetTrigger("Completed");
    }

    void Hit()
    {
        combat.FinishSlash();
    }
}