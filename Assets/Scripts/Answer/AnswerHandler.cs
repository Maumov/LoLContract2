using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnswerHandler : MonoBehaviour
{  
    
    public Answer answer;
    AnswerViewer answerViewer;
    QuestionHandler questionHandler;

    private void Awake() {
        answerViewer = FindObjectOfType<AnswerViewer>();
        questionHandler = FindObjectOfType<QuestionHandler>();
    }

    public void ShowAnswer(Answer ans) {
        answer = ans;
        answerViewer.Show(answer);
    }

    // Llamada por el boton
    public void CheckAnswer( Answer answer )
    {
        questionHandler.CheckAnswer(answer);
    }
    
}

public enum AnswerType {    Number, Denominator, Fraction  }

[System.Serializable]
public class Answer{

    public AnswerType answerType;
    public int numerator;
    public int denominator;

}