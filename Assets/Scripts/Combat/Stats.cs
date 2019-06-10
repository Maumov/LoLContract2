using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float maxHitPoints;
    public float currentHitPoints;

    public delegate void statsDelegate();
    public event statsDelegate OnDead, OnDamageReceived, OnRevive;

    private void Start() {
        currentHitPoints = maxHitPoints;
    }

    public void Revive() {
        currentHitPoints = maxHitPoints;
        if(OnRevive != null) {
            OnRevive();
        }
    }

    public void GetDamage(float damage) {
        currentHitPoints -= damage;

        if(currentHitPoints <= 0f) {
            Dead();
        } else {
            if(OnDamageReceived != null) {
                OnDamageReceived();
            }
        }
    }

    public void Dead() {

        if(OnDead != null) {
            OnDead();
        }

    }

    public bool isDead() {
        return currentHitPoints <= 0;
    }

}
