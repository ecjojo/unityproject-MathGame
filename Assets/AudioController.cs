using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioIncorrect;
    public AudioSource audioCorrect;
    public AudioSource audioResult;

    public void PlayIncorrect()
    {
        audioIncorrect.Play();
    }

    public void PlayCorrect()
    {
        audioCorrect.Play();
    }


    public void PlayResult()
    {
        audioResult.Play();
    }

}
