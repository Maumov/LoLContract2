using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCombatUI : MonoBehaviour
{
    public bool isPlayer;

    public GameObject UIToSpawn;



    private void Start() {
        Invoke("LateStart", 2f);    
    }

    void LateStart() {
        Combat[] statss = FindObjectsOfType<Combat>();
        foreach(Combat s in statss) {
            if(s.isPlayer == isPlayer) {
                s.GetComponent<Stats>().OnDead += ShowUI;
            }
        }
    }

    void ShowUI() {
        UIToSpawn.SetActive(true);
    }

    public void ButtonPressed() {
        LoadingScreen loadingScreen = FindObjectOfType<LoadingScreen>();
        loadingScreen.scene = "Hub";
        loadingScreen.ChangeLevel();
    }
}
