using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioAudio : MonoBehaviour
{
    public GameObject targetObject; // The target GameObject
    public float maxChangeDistance = 10f; // Maximum distance at which the audio changes start happening
    public float pitchMin = 0.5f; // Minimum pitch value
    public float pitchMax = 2.0f; // Maximum pitch value

    private AudioSource audioSource;
    private float initialPitch; // To remember the initial pitch of the audio source

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        initialPitch = audioSource.pitch; // Store the initial pitch
    }

    void Update()
    {
        // Calculate the distance between this GameObject and the target
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.transform.position);

        // Check if the target is within the maxChangeDistance
        if (distanceToTarget <= maxChangeDistance)
        {
            // Scale the pitch based on the distance
            float pitch = Mathf.Lerp(pitchMax, pitchMin, distanceToTarget / maxChangeDistance);
            audioSource.pitch = pitch;

            // Optionally interrupt the audio randomly
            if (!audioSource.isPlaying || Random.value > 0.95f) // 5% chance to interrupt each frame
            {
                // This would stop and start the audio to interrupt it. Adjust as needed.
                audioSource.Stop();
                audioSource.Play();
            }
        }
        else
        {
            // Reset pitch to initialPitch when the target is outside the maxChangeDistance
            if (audioSource.pitch != initialPitch)
            {
                audioSource.pitch = initialPitch;
            }
        }
    }
}
