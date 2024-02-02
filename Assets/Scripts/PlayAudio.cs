using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip startClip;
    public AudioClip functionClip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayStartClip();
    }



    public void PlayStartClip()
    {
        audioSource.clip = startClip;
        audioSource.Play();
    }

    public void PlayFunctionClip()
    {
        audioSource.clip = functionClip;
        audioSource.Play();
    }

}
