using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    Combat combat;
    [Header("Particles")]
    public GameObject LandFX;

    [Header("Sounds")]
    public AudioSource source;
    public AudioClip step;
    public AudioClip slash;
    public AudioClip readySound;

    private void Start()
    {
        Combat combat = GetComponent<Combat>();
        AnimatorController animator = GetComponent<AnimatorController>();
        combat.OnFinishSlash += PlaySlashSound;
        combat.OnReady += PlayReady;
        animator.OnStep += PlayStepSound;
    }

    void PlayStepSound()
    {
        PlaySFX(step);
    }

    void PlayReady()
    {
        InstantiateParticle(LandFX);
        PlaySFX(readySound);
    }

    void PlaySlashSound()
    {
        PlaySFX(slash);
    }

    void PlaySFX(AudioClip audioClip = null)
    {
        if (audioClip != null)
        {
            source.PlayOneShot(audioClip);
        }
    }

    void InstantiateParticle(ParticleFX FX)
    {
        if (FX != null || FX.particle != null)
        {
            Instantiate(FX.particle, transform.position + FX.positionOffset, Quaternion.identity, transform);
        }
    }

    void InstantiateParticle(GameObject FX)
    {
        if (FX != null)
        {
            Instantiate(FX, transform.position, Quaternion.identity, transform);
        }
    }
}