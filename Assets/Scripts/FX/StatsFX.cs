using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsFX : MonoBehaviour
{

    Stats stats;
    public ParticleFX DamageFX;
    public ParticleFX DeadFX;
    public ParticleFX ReviveFX;

    
    void Start()
    {
        stats = GetComponent<Stats>();
        stats.OnDamageReceived += Damage;
        stats.OnDead += Dead;
        stats.OnRevive += Revive;
    }

    void Damage() {
        InstantiateParticle(DamageFX);
    }

    void Dead() {
        InstantiateParticle(DeadFX);
    }

    void Revive() {
        InstantiateParticle(ReviveFX);
    }

    void InstantiateParticle(ParticleFX FX) {
        Instantiate(FX.particle, FX.positionOffset, Quaternion.identity, transform);
    }

}

[System.Serializable]
public class ParticleFX {
    public GameObject particle;
    public Vector3 positionOffset;
}

