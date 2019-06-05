using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionHandler : MonoBehaviour
{

    public delegate void delegadoRespuesta(bool sw);
    public event delegadoRespuesta OnRespuesta;

    public InfoTutorial infoTutorial;

    public void SetPregunta() {

    }

    public void MostrarTutorial() {

    }

    public void CheckAnswer(Answer respuesta) {

        bool sw = false;

        //---- Check answer

        //-----------------


        if(OnRespuesta != null) {
            OnRespuesta(sw);
        }
    }
}
[System.Serializable]
public class InfoTutorial {
    public string texto;
}

[System.Serializable]
public class Question {
    public int exerciseNumber;
    public int a;
    public int b;
    public int c;
    public int d;
    public int e;
    public Answer respuesta;
}

