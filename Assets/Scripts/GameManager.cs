using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

public class GameManager
{
    public static int progress;
    public static int maxProgress;
    public static int score;

    public static List<int> casosAPreguntar;
    public static GameObject boss;
    static int currentQuestion = 0;
    static int id;
    static List<int> bossesDone;

    public static void UpdateProgress() {
        score++;

        if(bossesDone == null) {
            bossesDone = new List<int>();
        }

        if(!bossesDone.Contains(id)) {
            bossesDone.Add(id);
            progress++;
        }
        if(LOLSDK.Instance.IsInitialized) {
            LOLSDK.Instance.SubmitProgress(score, progress, maxProgress);
        }
        Debug.Log(string.Format("Score: {0}, Progress: {1}, MaxProgress: {2}", score, progress, maxProgress));
        
    }

    public static bool CanEnterFinalBoss() {
        for(id = 0; id < 12; id++) {
            if(!IsBossKilled(id)) {
                return false;
            }
        }
        return true;
    }

    public static bool IsBossKilled(int id) {
        if(bossesDone == null) {
            bossesDone = new List<int>();
        }
        if(bossesDone.Contains(id)) {
            return true;
        }
        return false;
    }

    public static int GetNewQuestion() {
        int value;
        if(IsCombo(casosAPreguntar[currentQuestion])) {
            value = casosAPreguntar[currentQuestion];
            currentQuestion++;
            if(currentQuestion >= casosAPreguntar.Count) {
                currentQuestion = 0;
            }
        } else {
            value = ReturnRandomQuestion();
        }
        
        return value;
    }

    public static void SetQuestions(List<int> casos, GameObject theBoss, int i) {
        casosAPreguntar = casos;
        boss = theBoss;
        currentQuestion = 0;
        id = i;
    }

    public static bool posibleRandomQuestions(int value) {
        if(value == 0 ||
            value == 1 ||
            value == 2 ||
            value == 4 ||
            value == 5 ||
            value == 6 ||
            value == 7 ||
            value == 8 ||
            value == 12 ||
            value == 16 ||
            value == 17 ||
            value == 18 ||
            value == 19) {
            return false;
        } else {
            return true;
        }
    }

    public static bool IsCombo(int value) {
        if(value == 0 ||
            value == 1 ||
            value == 4 ||
            value == 5 ||
            value == 6 ||
            value == 7 ||
            value == 16 ||
            value == 17 ||
            value == 18 ||
            value == 19) {
            return false;
        } else {
            return true;
        }
    }


    public static int ReturnRandomQuestion() {
        int r = Random.Range(0, casosAPreguntar.Count);
        while(posibleRandomQuestions(r)) {
            r = Random.Range(0, casosAPreguntar.Count);
        }
        return r;
    }
}
