using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionViewer : MonoBehaviour
{
    public Question question;

    public List<GameObject> tipoPregunta;

    public List<TextMeshProUGUI> a, b, c, d, e, f, g;

    private void Start() {
        Invoke("LateStart", 2f);
    }

    private void LateStart() {
        Combat[] combats = FindObjectsOfType<Combat>();
        foreach(Combat c in combats) {
            c.OnStartAttack += Hide;
            c.OnFinishSlash += Show;
        }
    }

    public void Show(Question quest) {
        foreach(GameObject g in tipoPregunta) {
            g.SetActive(false);
        }
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

    void SetTexts(List<TextMeshProUGUI> list, string value) {
        foreach(TextMeshProUGUI t in list) {
            t.text = value;
        }
    }
    public void Hide() {
        Animator[] anim = GetComponentsInChildren<Animator>();
        foreach(Animator a in anim) {
            a.SetBool("IsHiden", true);
        }
    }
    public void Show() {
        Animator[] anim = GetComponentsInChildren<Animator>();
        foreach(Animator a in anim) {
            a.SetBool("IsHiden", false);
        }
    }
}
