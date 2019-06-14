using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStory : MonoBehaviour
{
    public List<string> Intro; //Intro
    public List<string> Boss6Killed; //On6BossesKilled
    public List<string> Boss12Killed; //On12BossKilled

    public MissionViewer viewer;
    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        for(int i = 0; i< 12; i++) {
            if(GameManager.IsBossKilled(i)) {
                count++;
            }
        }
        if(count == 0) {
            viewer.SetTexts(Intro);
        }
        if(count == 6) {
            viewer.SetTexts(Boss6Killed);
        }
        if(count == 12) {
            viewer.SetTexts(Boss12Killed);
        }

    }



}
