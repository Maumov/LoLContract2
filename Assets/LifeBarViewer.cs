using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarViewer : MonoBehaviour
{
    public bool isPlayer;
    Stats stats;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        Combat[] statss = FindObjectsOfType<Combat>();

        foreach(Combat s in statss) {
            if(s.isPlayer == isPlayer) {
                s.GetComponent<Stats>().OnDamageReceived += UpdateLifeBar;
            }
        }
        slider = GetComponent<Slider>();

    }
    
    void UpdateLifeBar() {
        slider.value = stats.currentHitPoints / stats.maxHitPoints;
    }
}
