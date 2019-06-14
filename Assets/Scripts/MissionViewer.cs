using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MissionViewer : MonoBehaviour
{
    public List<string> textos;
    public int currentShowing;
    TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetTexts(List<string> t) {
        textos = new List<string>();
        textos.AddRange(t);
        currentShowing = 0;
        Show();
    }

    public void ButtonPressed() {
        currentShowing++;
        if(currentShowing >= textos.Count) {
            Hide();
        } else {
            Show();
        }
    }

    void Show() {
        text.text = SharedState.LanguageDefs[textos[currentShowing]];
    }

    void Hide() {
        gameObject.SetActive(false);
    }
}
