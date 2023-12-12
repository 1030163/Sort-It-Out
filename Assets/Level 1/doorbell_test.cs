using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorbell_test : MonoBehaviour

{
    public AudioClip doorbellSound; 
    public AudioSource audioSource;

    void Start()
    {
       
        audioSource = GetComponent<AudioSource>();

        
        audioSource.clip = doorbellSound;
    }

    void OnMouseDown()
    {
      
        audioSource.Play();
    }
}

