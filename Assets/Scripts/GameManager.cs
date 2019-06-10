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

    public static void UpdateProgress() {
        LOLSDK.Instance.SubmitProgress(score, progress, maxProgress);
    }

    public static int GetNewQuestion() {
        return Random.Range(0, casosAPreguntar.Count);

    }
}
