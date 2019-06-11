using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnBoss();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBoss() {
        GameObject boss = Instantiate(GameManager.boss,transform);
    }
}
