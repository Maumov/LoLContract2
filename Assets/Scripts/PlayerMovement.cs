using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed;
    public float rotationSpeed;
    
    float vertical;
    float horizontal;

    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();   
        Move();
    }

    void GetInputs() {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void Move() {
        Vector3 dir = new Vector3(horizontal,0f, vertical);
        dir.Normalize();
        dir *= movementSpeed;
        dir += Physics.gravity;
        characterController.Move(dir * Time.deltaTime);
        transform.LookAt(transform.position + new Vector3(horizontal, 0f, vertical));
    }
}
