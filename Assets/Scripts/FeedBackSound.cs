using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackSound : MonoBehaviour
{
    [Header("SFX")]
    public AudioSource correctSound;
    public AudioSource incorrectSound;

    // Start is called before the first frame update
    void Start()
    {
        QuestionHandler handler = FindObjectOfType<QuestionHandler>();
        handler.OnCorrect += PlayCorrectSound;
        handler.OnWrong += PlayWrongSound;
    }

    void PlayCorrectSound()
    {
        incorrectSound.Play();
    }

    void PlayWrongSound()
    {
        incorrectSound.Play();
    }
}