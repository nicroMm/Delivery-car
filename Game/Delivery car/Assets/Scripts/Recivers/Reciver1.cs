using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciver1 : MonoBehaviour
{
    [SerializeField] private GameObject package;
    [SerializeField] private GameObject customerSound;
    AudioSource audioSource;
    private void Start() 
    {
        audioSource = customerSound.GetComponent<AudioSource>();    
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        audioSource.Play();
        package.SetActive(true);
    }
}
