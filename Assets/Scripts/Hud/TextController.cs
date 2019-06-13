using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextController : MonoBehaviour
{
    public Queue<Frases> message;
    public TextMeshProUGUI text;
    public TextMeshProUGUI buttonText;
    public bool completed;
    public float delay = 1;
    private float delayCounter;

    UnityEvent eventoActual;

    public GameManager gameManager;

    private void Start()
    {
        delayCounter = delay;
    }

    public void UpdateMessage()
    {
        if(delayCounter <= Time.time)
        {
            if(eventoActual != null) {
                eventoActual.Invoke();
            }
            if (!completed)
            {
                eventoActual = message.Peek().evento;
                string word = message.Dequeue().key;
                text.text = SharedState.LanguageDefs[word];
                if (message.Count == 0)
                {
                    completed = true;
                    buttonText.text = SharedState.LanguageDefs["ok"];
                }
            }
            else
            {
                gameManager.TutorialFinish();
                TurnOffThisObject();
            }

            delayCounter = Time.time + delay;
        }

    }

    public void SetText(List<Frases> data)
    {
        eventoActual = null;
        completed = false;
        message = new Queue<Frases>(data);
        buttonText.text = SharedState.LanguageDefs["next"];
        UpdateMessage();
        
    }

    public void AddText(Frases data) {
        message.Enqueue(data);
    }


    public void TurnOffThisObject()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void MakeUncompleted()
    {
        completed = false;
    }
}