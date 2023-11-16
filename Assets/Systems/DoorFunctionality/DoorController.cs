using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorController : MonoBehaviour
{
    [Header("Door Rotation")]
    public float openAngle = 90f;
    public float rotationSpeed = 2f;

    private Quaternion closedRotation;
    private Quaternion openRotation;



    private bool isOpen = false;

    public bool hasPermission = true;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(0, openAngle, 0) * closedRotation;
    }

    private void OnSelectEntered(XRBaseInteractor interactor)
    {
        // Check if the interaction is from a poke
        if (interactor is XRPokeInteractor)
        {
            ToggleDoorState();
        }
    }

    private void ToggleDoorState()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            Debug.Log("Door Opened");
            transform.rotation = Quaternion.RotateTowards(transform.rotation, openRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Door Closed");
            transform.rotation = Quaternion.RotateTowards(transform.rotation, closedRotation, rotationSpeed * Time.deltaTime);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ToggleDoorState();
        }
    }

}
