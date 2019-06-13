using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesController : MonoBehaviour
{
    public TextController textPrefab;
    public GameObject canvas;


    public void SpawnText(List<Frases> keyNames)
    {
        canvas.SetActive(true);
        List<Frases> list = new List<Frases>();
        list.AddRange(keyNames);
        if(list != null)
        {
            textPrefab.SetText(list);
        }
    }
}