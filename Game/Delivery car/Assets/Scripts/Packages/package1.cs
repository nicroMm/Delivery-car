using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class package1 : MonoBehaviour
{
    [SerializeField] private GameObject reciver;
    [SerializeField] private GameObject packageAudio;
    AudioSource audioSource;
    private void Start() 
    {
        audioSource = packageAudio.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        audioSource.Play(0);
        reciver.SetActive(true);      
    }
}


