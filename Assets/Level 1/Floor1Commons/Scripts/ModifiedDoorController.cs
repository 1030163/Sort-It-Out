using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ModifiedDoorController : MonoBehaviour
{
    private bool isOpen = false;
    public bool openInside;

    public bool hasPermission = true;
    private Animator animator;
    private bool scriptedActionComplete = false;
    public AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource= GetComponent<AudioSource>();
    }

    private void OnSelectEntered(XRBaseInteractor interactor)
    {
        // Check if the interaction is from a poke
        if (interactor is XRPokeInteractor)
        {
            ToggleDoorState();
        }
    }

    private void RotateDoor(float targetAngle)
    {

    }

    public void ToggleDoorState()
    {
        if (hasPermission)
        {
            if (!isOpen)
            {
                isOpen = true;
                animator.SetTrigger("DoorMove");
                animator.SetBool("IsOpen", true);

                if (openInside)
                {
                    animator.SetBool("isInside", true);
                }
                else
                {
                    animator.SetBool("isInside", false);
                }
            }
            else
            {
                isOpen = false;
                animator.SetTrigger("DoorMove");
                animator.SetBool("IsOpen", false);
            }
        }
    }

    public void ScriptedToggleDoorState()
    {
        Debug.Log("ScriptedToggleDoorState() called");
        if(scriptedActionComplete == false)
        {
            if (!isOpen)
            {
                isOpen = true;
                PlayDoorAudio();
                animator.SetTrigger("DoorMove");
                
                animator.SetBool("IsOpen", true);
                scriptedActionComplete = true;
                if (openInside)
                {
                    animator.SetBool("isInside", true);
                }
                else
                {
                    animator.SetBool("isInside", false);
                }
            }
            else
            {
                isOpen = false;
                PlayDoorAudio();
                animator.SetTrigger("DoorMove");
                
                animator.SetBool("IsOpen", false);
                scriptedActionComplete = true;
            }
        }
        
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ToggleDoorState();
        }


        //if (isOpen)
        //{
        //    RotateDoor(openAngle);
        //}
        //else
        //{
        //    RotateDoor(0f);
        //}
    }

    public void PlayDoorAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
