using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip scaryClip;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = scaryClip;
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.volume = 1f;
        audioSource.Play();
        DontDestroyOnLoad(gameObject);
    }
}
