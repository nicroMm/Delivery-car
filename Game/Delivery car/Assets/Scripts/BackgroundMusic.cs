using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] AudioClip backgroundMusic;
    AudioSource audioSource;
    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(backgroundMusic);
        }
    }
}
