using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageModifier : MonoBehaviour
{
    public string key;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshPro>().text = SharedState.LanguageDefs[key];
    }
    
}
