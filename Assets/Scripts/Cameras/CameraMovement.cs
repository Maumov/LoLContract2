using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public Vector3 Offset = new Vector3 (0f, 5f, -5f);
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + Offset;
    }
}
