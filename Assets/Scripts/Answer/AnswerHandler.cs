using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnswerHandler : MonoBehaviour
{  
    
    public Answer answer;
    public AnswerViewer answerViewer;
    public QuestionHandler questionHandler;

    private void Awake() {
        
    }

    public void ShowAnswer(Answer ans) {
        Debug.Log(ans);
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