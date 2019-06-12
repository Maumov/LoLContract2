using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int id;
    public bool isLastBoss;
    public GameObject boss;
    public List<int> casosAPreguntar;
    LoadingScreen loadingScreen;
    Animator anim;
    AudioSource audio;

    public GameObject DoorStatusOn, DoorStatusOff;

    delegate void doorDelegate();
    event doorDelegate OnEnterInteraction, OnExitInteraction;

    bool interacting;


    private void Start() {
        audio = GetComponent<AudioSource>();
        loadingScreen = FindObjectOfType<LoadingScreen>();
        anim = GetComponent<Animator>();
        SetDoorStatus();
        if(isLastBoss) {
            if(!GameManager.CanEnterFinalBoss()) {
                GetComponent<SphereCollider>().enabled = false;
            }
        }
    }

    private void Update() {
        if(interacting) {
            if(Input.GetButtonDown("Jump")) {
                Use();
            }
        }
    }

    public void Use() {
        FindObjectOfType<PlayerMovement>().enabled = false;
        anim.SetTrigger("Open");
        audio.Play();
        Invoke("EnterDoor", 1f);
    }

    void EnterDoor() {
        GameManager.SetQuestions(casosAPreguntar, boss,id);
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

    void SetDoorStatus() {

        if(GameManager.IsBossKilled(id)) {
            if(DoorStatusOn != null) {
                DoorStatusOn.SetActive(true);
            }
            if(DoorStatusOff != null) {
                DoorStatusOff.SetActive(false);
            }
            
        } else {
            if(DoorStatusOn != null) {
                DoorStatusOn.SetActive(false);
            }
            if(DoorStatusOff != null) {
                DoorStatusOff.SetActive(true);
            }
        }
    }

}
