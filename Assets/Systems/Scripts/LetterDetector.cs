using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterDetector : MonoBehaviour
{
    public ParticleSystem fanfareParticles;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with the box
        if (other.gameObject.CompareTag("Delivery"))
        {
            // Play the particle system
            fanfareParticles.Play();
            Debug.Log("Letter Delivered");
        }
    }
}
