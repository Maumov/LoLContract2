using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int puertaId;
    public DoorValues doorValues;
    //public int id;
    public bool isLastBoss;
    //public GameObject boss;
    //public List<int> casosAPreguntar;
    LoadingScreen loadingScreen;
    Animator anim;
    AudioSource audio;

    public GameObject DoorStatusOn, DoorStatusOff;

    delegate void doorDelegate();
    event doorDelegate OnEnterInteraction, OnExitInteraction;

    bool interacting;

    public List<GameObject> DoorsStatusOn, DoorsStatusOff;
    bool statusIsOn;
    private void Start() {
        //GameManager.ResetDoorsValues();
        audio = GetComponent<AudioSource>();
        loadingScreen = FindObjectOfType<LoadingScreen>();
        anim = GetComponent<Animator>();
        
        Invoke("LateStart", 1f);
    }

    void LateStart() {
        //DoorValues doorValues = new DoorValues();
        //doorValues.id = id;
        //doorValues.boss = boss;
        //doorValues.casosAPreguntar = casosAPreguntar;
        //GameManager.AddDoorsValues(doorValues);
        //DoorValues doorValues = new DoorValues();
        doorValues = GameManager.GetDoorValuesById(puertaId);
        SetDoorStatus();
        if(isLastBoss) {
            if(!GameManager.CanEnterFinalBoss()) {
                GetComponent<SphereCollider>().enabled = false;
            }
            for(int i = 0; i < 12; i++) {
                if(GameManager.IsBossKilled(i)) {
                    if(DoorsStatusOn[i] != null) {
                        DoorsStatusOn[i].SetActive(true);
                    }
                    if(DoorsStatusOff[i] != null) {
                        DoorsStatusOff[i].SetActive(false);
                    }
                } else {
                    if(DoorsStatusOn[i] != null) {
                        DoorsStatusOn[i].SetActive(false);
                    }
                    if(DoorsStatusOff[i] != null) {
                        DoorsStatusOff[i].SetActive(true);
                    }
                }
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

        if(!statusIsOn) {
            int nextBossId = GameManager.NextBossId();
            GameManager.SetDoorIdToValues(puertaId, nextBossId);
            doorValues = GameManager.GetDoorValuesById(puertaId);
        }

        GameManager.SetQuestions(doorValues.casosAPreguntar, doorValues.boss, doorValues.id);
        Invoke("EnterDoor", 1f);
    }

    void EnterDoor() {
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
        if(doorValues != null) {
            if(GameManager.IsBossKilled(doorValues.id)) {
                if(DoorStatusOn != null) {
                    DoorStatusOn.SetActive(true);
                }
                if(DoorStatusOff != null) {
                    DoorStatusOff.SetActive(false);
                }
                statusIsOn = true;
            } else {
                if(DoorStatusOn != null) {
                    DoorStatusOn.SetActive(false);
                }
                if(DoorStatusOff != null) {
                    DoorStatusOff.SetActive(true);
                }
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
