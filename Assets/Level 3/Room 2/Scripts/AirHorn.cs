using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHorn : MonoBehaviour
{
    public AudioClip airhornSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Package"))
        {
            // Play the airhorn sound
            AudioSource.PlayClipAtPoint(airhornSound, transform.position);

            // You can add additional logic here, dialogue ? .

        }
    }
}
