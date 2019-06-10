using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimatorController : MonoBehaviour
{
    Animator anim;
    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update() {

        SetAnimatorValues();
    }

    void SetAnimatorValues() {

        if(Mathf.Abs(characterController.velocity.x) + Mathf.Abs(characterController.velocity.z) > 0) {
            anim.SetBool("Moving", true);
        } else {
            anim.SetBool("Moving", false);
        }
    }

}
