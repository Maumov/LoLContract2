using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionViewer : MonoBehaviour
{
    public Question question;

    public List<GameObject> tipoPregunta;

    public List<Text> a, b, c, d, e;

    
    public void Show(Question quest) {
        question = quest;

        switch(question.exerciseNumber) {
            case 0:
                tipoPregunta[question.exerciseNumber].SetActive(true);
                a[question.exerciseNumber].text = question.a.ToString();
                b[question.exerciseNumber].text = question.b.ToString();
                c[question.exerciseNumber].text = question.c.ToString();
                d[question.exerciseNumber].text = question.d.ToString();
                e[question.exerciseNumber].text = question.e.ToString();
            break;
            case 1:
                tipoPregunta[question.exerciseNumber].SetActive(true);
                a[question.exerciseNumber].text = question.a.ToString();
                b[question.exerciseNumber].text = question.b.ToString();
                c[question.exerciseNumber].text = question.c.ToString();
                d[question.exerciseNumber].text = question.d.ToString();
                e[question.exerciseNumber].text = question.e.ToString();
            break;
        }
    }
}
