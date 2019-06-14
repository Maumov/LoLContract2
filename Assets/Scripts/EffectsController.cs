using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
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
        combat.OnReady += PlayReadySound;
        animator.OnStep += PlayStepSound;
    }

    void PlayStepSound()
    {
        PlaySFX(step);
    }

    void PlayReadySound()
    {
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
}