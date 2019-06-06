﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerViewer : MonoBehaviour
{
    public Answer answer;
    public List<GameObject> tipoRespuesta;
    public List<InputField> incognita1, incognita2;
    AnswerHandler answerHandler;

    void Start() {
        answerHandler = FindObjectOfType<AnswerHandler>();        
    }

    public void Show(Answer ans) {
        answer = ans;
        foreach(GameObject g in tipoRespuesta) {
            g.SetActive(false);
        }
        tipoRespuesta[(int)answer.answerType].SetActive(true);
        incognita1[(int)answer.answerType].text = "";
        incognita2[(int)answer.answerType].text = "";
    }

    public void ButtonPressed() {
        Answer a = new Answer();
        a.numerator = int.Parse(incognita1[(int)answer.answerType].text);
        a.denominator = int.Parse(incognita2[(int)answer.answerType].text);
        answerHandler.CheckAnswer(a);
    }
}
