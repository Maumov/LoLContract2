using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnswerHandler : MonoBehaviour
{  
    
    public Answer answer;
    public AnswerViewer answerViewer;
    public AnswerViewer answerViewerRevive;
    public QuestionHandler questionHandler;

    private void Awake() {
        
    }

    public void ShowAnswer(Answer ans) {
        Debug.Log(ans);
        answer = ans;
        answerViewer.Show(answer);
        answerViewerRevive.Show(answer);
    }

    // Llamada por el boton
    public void CheckAnswer( Answer answer, string accion)
    {
        questionHandler.CheckAnswer(answer, accion);
    }
    
}

public enum AnswerType {    Number, Denominator, Fraction  }

[System.Serializable]
public class Answer{

    public AnswerType answerType;
    public int numerator;
    public int denominator;


    public override string ToString() {
        return "AT: " + answerType.ToString() + ", N: " + numerator + "," + "D: " + denominator;
    }
}