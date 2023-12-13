using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Doorbell : MonoBehaviour
{
    [Header("Changeable Values")]
    [SerializeField] float waitTime;

    [Header("References")]
    [SerializeField] TextMeshPro interactionText;
    [SerializeField] DoorController doorController;
    [SerializeField] AudioClip doorbellSound;
    [SerializeField] AudioSource audioSource;
    public bool isDoorOpen;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            interactionText.gameObject.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            RingDoorbell();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.gameObject.SetActive(false);
            isDoorOpen = false;
        }
    }

    public void RingDoorbell()
    {
        StartCoroutine(WaitCoroutine(waitTime));
        OpenDoor();
        PlayDoorbellSound(); 
    }

    IEnumerator WaitCoroutine(float time)
    {
        yield return new WaitForSeconds(time);


    }

    private void OpenDoor()
    {
        // Check if the player is still in the interaction zone before opening the door
        if (interactionText.gameObject.activeSelf)
        {
            doorController.hasPermission = true;
            doorController.DoorStateChange();
            isDoorOpen = true;
        }
    }

    private void PlayDoorbellSound()
    {
        if (doorbellSound != null && audioSource != null)
        {
            Debug.Log("Playing doorbell sound");
            audioSource.PlayOneShot(doorbellSound);
            
        }
        else
        {
            AudioSource.PlayClipAtPoint(doorbellSound, transform.position);
        }
        
        
    }
}
