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


    public float timer = 20f;
    float timeRemaining = 0f;
    bool timerStarted = false;

    float timeInFight;

    public GameObject FinalBossUI;

    private void Start() {
        timeInFight = 0f;
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

        timeInFight += Time.deltaTime;

        if(countDown != null) {
            if(!timerStarted) {
                return;
            }
            timeRemaining -= Time.deltaTime;
            timeRemaining = Mathf.Clamp(timeRemaining, 0f, 100f);
            countDown.text = ((int)timeRemaining).ToString();
            if(timeRemaining <= 0f) {
                DisableButton();
                timerStarted = false;
            }
        }
    }

    void DisableButton() {
        revive.interactable = false;
    }

    void ShowUI() {
        if(!isPlayer) { 
            
            GameManager.UpdateProgress(1250 - (int)timeInFight);
            if(GameManager.id == 12) {
                FinalBossUI.SetActive(true);
                Invoke("EndGame", 2f);
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
        if(FinalBossUI != null)
        {
            FinalBossUI.SetActive(false);
        }
    }

    void EndGame() {
        GameManager.FinishGame();
    }

    void StartCountDown() {
        revive.interactable = true;
        timeRemaining = timer;
        countDown.text = ((int)timeRemaining).ToString();
        timerStarted = true;
    }

    public void ButtonPressed() {
      
        LoadingScreen loadingScreen = FindObjectOfType<LoadingScreen>();
        loadingScreen.scene = "Hub";
        loadingScreen.ChangeLevel();
    }

}
