using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveUI : MonoBehaviour
{
    EndCombatUI endCombatUI;
 
    private void Start() {
        endCombatUI = GetComponent<EndCombatUI>();
        Invoke("LateStart", 2f);
    }

    void LateStart() {  
        Combat[] statss = FindObjectsOfType<Combat>();
        foreach(Combat s in statss) {
            if(s.isPlayer) {
                s.GetComponent<Stats>().OnRevive += hideUI;
            }
        }
    }


    void hideUI() {
        endCombatUI.HideUI();
    }

}
