using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorController : MonoBehaviour
{
    private bool isOpen = false;

    public bool hasPermission = true;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
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

    private void ToggleDoorState()
    {
        if (hasPermission)
        {
            if (!isOpen)
            {
                isOpen = true;
                animator.SetTrigger("DoorMove");
                animator.SetBool("IsOpen", true);
            }
            else
            {
                isOpen = false;
                animator.SetTrigger("DoorMove");
                animator.SetBool("IsOpen", false);
            }
        }



    }

    private void Update()
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

}
