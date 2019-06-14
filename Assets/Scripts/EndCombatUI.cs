using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EndCombatUI : MonoBehaviour {
    public bool isPlayer;

    public GameObject UIToSpawn;

    public Button revive;
    public TextMeshProUGUI countDown;
    public TextMeshProUGUI scoreText;

    public float timer;
    bool timerStarted = false;

    public GameObject FinalBossUI;

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

    private void Update() {
        if(countDown != null) {
            if(!timerStarted) {
                return;
            }
            timer -= Time.deltaTime;
            timer = Mathf.Clamp(timer, 0f, 100f);
            countDown.text = ((int)timer).ToString();
            if(timer <= 0f) {
                DisableButton();
            }
        }
    }

    void DisableButton() {
        revive.interactable = false;
    }

    void ShowUI() {
        if(!isPlayer) {
            GameManager.UpdateProgress();
            if(GameManager.id == 13) {
                FinalBossUI.SetActive(true);
                UIToSpawn.SetActive(false);
            } else {
                scoreText.text = GameManager.score.ToString();
                FinalBossUI.SetActive(false);
                UIToSpawn.SetActive(true);
            }
        } else {
            StartCountDown();
            UIToSpawn.SetActive(true);
        }
    }

    public void HideUI() {
        UIToSpawn.SetActive(false);
        FinalBossUI.SetActive(false);
    }

    void StartCountDown() {
        timerStarted = true;
    }

    public void ButtonPressed() {
        LoadingScreen loadingScreen = FindObjectOfType<LoadingScreen>();
        loadingScreen.scene = "Hub";
        loadingScreen.ChangeLevel();
    }

}
