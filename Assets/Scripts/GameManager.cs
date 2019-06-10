using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;


public class GameManager : MonoBehaviour
{
    public static int progress;
    public static int maxProgress;
    public static int score;

    public static List<int> casosAPreguntar;
    public static GameObject boss;
    static int currentQuestion = 0;

    public static void UpdateProgress() {
        LOLSDK.Instance.SubmitProgress(score, progress, maxProgress);
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

    public static void SetQuestions(List<int> casos, GameObject theBoss) {
        casosAPreguntar = casos;
        boss = theBoss;
        currentQuestion = 0;
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
