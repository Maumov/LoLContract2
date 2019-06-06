using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void enemyDelegate();
    public event enemyDelegate OnSpawn, OnAttack;



    void Start() {

        if(OnSpawn != null) {
            OnSpawn();
        }
        
    }

}

