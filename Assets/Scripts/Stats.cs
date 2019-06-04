using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float maxHitPoints;
    public float currentHitPoints;

    public delegate void deadDelegate();
    public event deadDelegate OnDead;

    public void GetDamage(float damage) {
        currentHitPoints -= damage;
        if(currentHitPoints <= 0f) {
            Dead();
        }
    }

    public void Dead() {

    }

}
