using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource correctAnswerSfx;
    [SerializeField] private AudioSource wrongAnswerSfx;

    public void PlayCorrectAnswerAudio()
    {
        correctAnswerSfx.Play();
    }

    public void PlayWrongAnswerAudio()
    {
        wrongAnswerSfx.Play();
    }
}