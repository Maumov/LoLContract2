using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerViewer : MonoBehaviour
{

    public Image image, image2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateValue(float value) {
        //public void UpdateValue(float value, float value2) {
        image.fillAmount = value;
        //image2.fillAmount = value2;
    }
}
