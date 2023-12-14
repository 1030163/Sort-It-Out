using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioAudio : MonoBehaviour
{
    public GameObject targetObject; // The target GameObject
    public float maxChangeDistance = 10f; // Maximum distance at which the audio changes start happening
    public float pitchMin = 0.5f; // Minimum pitch value
    public float pitchMax = 2.0f; // Maximum pitch value
    public float playDuration = 0.25f;

    public AudioSource audioSource;
    //public AudioSource manScreaming;
    private float initialPitch; // To remember the initial pitch of the audio source

    public bool isDelivered = false;
    public bool isInsideApart = false;

    void Start()
    {
        targetObject = GameObject.Find("Ghost");
        //audioSource = GetComponent<AudioSource>();
        initialPitch = audioSource.pitch; // Store the initial pitch
    }

    void Update()
    {
        if (isDelivered == false && isInsideApart == true)
        {
            // Calculate the distance between this GameObject and the target
            float distanceToTarget = Vector3.Distance(transform.position, targetObject.transform.position);

            // Determine if the object is within the range to change pitch and potentially interrupt
            if (distanceToTarget <= maxChangeDistance)
            {
                // Scale the chance of interruption based on distance (lower chance when closer)
                // This formula reduces the interruption frequency more significantly as you get closer
                float interruptionChance = Mathf.Pow(distanceToTarget / maxChangeDistance, 2);

                // Scale the pitch based on the distance (closer to initial pitch when near the target)
                float pitch = Mathf.Lerp(initialPitch, pitchMax, distanceToTarget / maxChangeDistance);
                audioSource.pitch = pitch;

                // Interrupt the audio based on the calculated chance
                if (!audioSource.isPlaying || Random.value < interruptionChance)
                {
                    audioSource.Stop();
                    audioSource.Play();
                }
            }
            else
            {
                // Ensure no interruptions and reset pitch when the target is outside the maxChangeDistance
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }

                if (audioSource.pitch != initialPitch)
                {
                    audioSource.pitch = initialPitch;
                }
            }
        }
    }

    IEnumerator PlayAudioForDuration(AudioSource audioSource, float duration)
    {
        if (audioSource == null) yield break; // Exit if no audio source is provided

        audioSource.Play();
        yield return new WaitForSeconds(duration);
        audioSource.Stop();
    }

    public void Delivered()
    {
        audioSource.Stop();
        isDelivered = true;
    }
}