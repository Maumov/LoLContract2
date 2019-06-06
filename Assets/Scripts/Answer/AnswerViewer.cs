using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerViewer : MonoBehaviour
{
    public Answer answer;

    public List<GameObject> tipoRespuesta;

    public List<Text> incognita1, incognita2;

    public AnswerHandler answerHandler;

    void Start() {
        answerHandler = FindObjectOfType<AnswerHandler>();        
    }

    public void Show(Answer ans) {
        answer = ans;
        switch(answer.answerType) {
            case AnswerType.Number:
            tipoRespuesta[0].SetActive(true);
            break;
            case AnswerType.Denominator:
            tipoRespuesta[1].SetActive(true);
            break;
            case AnswerType.Fraction:
            tipoRespuesta[2].SetActive(true);
            break;
        }
    }

    public void ButtonPressed() {

        Answer a = new Answer();
        switch(a.answerType) {
            case AnswerType.Number:
            a.numerator = int.Parse(incognita1[0].text);
            a.denominator = int.Parse(incognita1[0].text);
            break;
            case AnswerType.Denominator:
            a.numerator = int.Parse(incognita1[1].text);
            a.denominator = int.Parse(incognita1[1].text);
            break;
            case AnswerType.Fraction:
            a.numerator = int.Parse(incognita1[2].text);
            a.denominator = int.Parse(incognita1[2].text);
            break;
        }
        answerHandler.CheckAnswer(a);
    }
}
