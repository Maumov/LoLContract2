using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{

    public delegate void delegadoRespuesta(bool sw);
    public event delegadoRespuesta OnRespuesta;

    public InfoTutorial infoTutorial;

    public void SetPregunta() {

    }

    public void MostrarTutorial() {

    }

    public void CheckAnswer(Respuesta respuesta) {

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
