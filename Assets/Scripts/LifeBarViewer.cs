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
        Invoke("lateStart", 2f);
        slider = GetComponent<Slider>();

    }
    
    void UpdateLifeBar() {
        slider.value = stats.currentHitPoints / stats.maxHitPoints;
    }

    void lateStart() {
        Combat[] statss = FindObjectsOfType<Combat>();

        foreach(Combat s in statss) {
            if(s.isPlayer == isPlayer) {
                s.GetComponent<Stats>().OnHpChange += UpdateLifeBar;
                stats = s.GetComponent<Stats>();
            }
        }
    }
}
