using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Answer : MonoBehaviour
{
    [Header("UI")]
    public InputField incognita1;
    public InputField incognita2;
    public GameObject line;
    public Question question;
    string defaultValue;
    public AnswerType type;
    float numerator;
    float denominator;

    public void SetAnswerType(AnswerType answerType)
    {
        type = answerType;
        ResetValues();
        DisplayAnswerFields();
    }

    public void DisplayAnswerFields()
    {
        switch (type)
        {
            case AnswerType.Denominator:
                incognita1.enabled = false;
                break;
            case AnswerType.Number:
                incognita2.gameObject.SetActive(false);
                line.SetActive(false);
                break;
        }
    }

    float AnswerValue()
    {
        numerator = float.Parse(incognita1.text);
        denominator = float.Parse(incognita2.text);

        switch (type)
        {
            case AnswerType.Denominator:
                return (1 / denominator);

            case AnswerType.Fraction:
                return (numerator / denominator);

            case AnswerType.Number:
                return numerator;
            default:
                return -1;
        }
    }

    // Llamada por el boton
    public void CheckAnswer()
    {
        question.CheckAnswer(AnswerValue);
    }

    public void ResetValues()
    {
        numerator = 1;
        denominator = 1;

        incognita1.gameObject.SetActive(true);
        incognita1.enabled = true;
        incognita1.text = defaultValue;

        incognita2.gameObject.SetActive(true);
        incognita2.enabled = true;
        incognita2.text = defaultValue;
    }
}

public enum AnswerType { Denominator, Fraction, Number }

public class Respuesta {
    float denominador;
    float numerador;
    float numero;
}