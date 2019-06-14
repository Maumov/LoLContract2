using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsFX : MonoBehaviour
{

    Stats stats;
    public ParticleFX DamageFX;
    public ParticleFX DeadFX;
    public ParticleFX ReviveFX;

    public AudioSource audioSource;
    public AudioClip DamageSFX;
    public AudioClip DeadSFX;
    public AudioClip ReviveSFX;


    void Start()
    {
        stats = GetComponent<Stats>();
        stats.OnDamageReceived += Damage;
        stats.OnDead += Dead;
        stats.OnRevive += Revive;
    }

    void Damage() {
        InstantiateParticle(DamageFX);
        PlaySFX(DamageSFX);
    }

    void Dead() {
        InstantiateParticle(DeadFX);
        PlaySFX(DeadSFX);
    }

    void Revive() {
        InstantiateParticle(ReviveFX);
        PlaySFX(ReviveSFX);
    }

    void InstantiateParticle(ParticleFX FX) {
        if(FX != null)
        {
            Instantiate(FX.particle, FX.positionOffset, Quaternion.identity, transform);
        }
    }

    void PlaySFX(AudioClip audioClip = null) {
        if(audioClip != null) {
            audioSource.PlayOneShot(audioClip);
        }
    }


}

[System.Serializable]
public class ParticleFX {
    public GameObject particle;
    public Vector3 positionOffset;
}

