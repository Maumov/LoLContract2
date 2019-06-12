using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource step;
    public AudioSource slash;
    public AudioSource readySound;


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
        step.Play();
    }

    void PlayReadySound()
    {
        readySound.Play();
    }

    void PlaySlashSound()
    {
        slash.Play();
    }
}
