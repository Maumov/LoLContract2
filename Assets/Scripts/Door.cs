using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject boss;
    public List<int> casosAPreguntar;
    public bool isCombo;
    LoadingScreen loadingScreen;
    Animator anim;

    delegate void doorDelegate();
    event doorDelegate OnEnterInteraction, OnExitInteraction;

    bool interacting;


    private void Start() {
        loadingScreen = FindObjectOfType<LoadingScreen>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        if(interacting) {
            if(Input.GetButtonDown("Jump")) {
                Use();
            }
        }
    }

    public void Use() {
        anim.SetTrigger("Open");
        Invoke("EnterDoor", 1f);
    }

    void EnterDoor() {
        GameManager.SetQuestions(casosAPreguntar, boss);
        loadingScreen.ChangeLevel();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Player")) {
            if(OnEnterInteraction != null) {
                OnEnterInteraction();
            }
            interacting = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag.Equals("Player")) {
            if(OnExitInteraction != null) {
                OnExitInteraction();
            }
            interacting = false;
        }
    }

}
