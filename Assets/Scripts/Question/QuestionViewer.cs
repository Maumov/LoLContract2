using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionViewer : MonoBehaviour
{
    public Question question;

    public List<GameObject> tipoPregunta;

    public List<Text> a, b, c, d, e, f, g;
    
    public void Show(Question quest) {
        question = quest;
        SetTexts(a, question.a.ToString());
        SetTexts(b, question.b.ToString());
        SetTexts(c, question.c.ToString());
        SetTexts(d, question.d.ToString());
        SetTexts(e, question.e.ToString());
        SetTexts(f, question.f.ToString());
        SetTexts(g, question.g.ToString());
        tipoPregunta[question.exerciseNumber].SetActive(true);
    }

    void SetTexts(List<Text> list, string value) {
        foreach(Text t in list) {
            t.text = value;
        }
    }

}
