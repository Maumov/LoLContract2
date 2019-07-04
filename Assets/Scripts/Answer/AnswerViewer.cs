using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerViewer : MonoBehaviour {
    public Answer answer;
    public List<GameObject> tipoRespuesta;
    public List<InputField> incognita1, incognita2;

    public AnswerHandler answerHandler;

    private void Start() {
        Invoke("LateStart", 2f);
    }

    private void LateStart() {
        Combat[] combats = FindObjectsOfType<Combat>();
        foreach(Combat c in combats) {
            c.OnStartAttack += Hide;
            c.OnReturnToPosition += Show;
        }
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

    public void ButtonPressed(string botonPresionado) {
        Answer a = new Answer();
        if(incognita1[(int)answer.answerType].text != "") {
            a.numerator = int.Parse(incognita1[(int)answer.answerType].text);
        }
        if(incognita2[(int)answer.answerType].text != "") {
            a.denominator = int.Parse(incognita2[(int)answer.answerType].text);
        }
        answerHandler.CheckAnswer(a, botonPresionado);
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
