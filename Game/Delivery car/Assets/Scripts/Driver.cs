using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 180f;
    [SerializeField] float moveSpeed = 9f;
    [SerializeField] float slowSpeed = 3f;
    [SerializeField] float boostSpeed = 13f;
    [SerializeField] AudioClip accelerationSound;
    [SerializeField] AudioClip breakSound;
    [SerializeField] AudioClip engineSound;
    AudioSource audioSource;
    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CarSounds();
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "SpeedUp")
        {
            moveSpeed = boostSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
            moveSpeed = slowSpeed;
    }

    void CarSounds()
    {
       if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioSource.Stop();
            audioSource.PlayOneShot(accelerationSound);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSource.Stop();
            audioSource.PlayOneShot(breakSound);
            audioSource.PlayOneShot(accelerationSound);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            audioSource.Stop();
        }
        else if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engineSound);
        }

    }
}
