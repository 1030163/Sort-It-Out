using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorController : MonoBehaviour
{
    public bool openInside;
    private bool isOpen = false;

    public bool hasPermission = true;
    private Animator animator;

    private GameObject player;
    private bool playerInRange = false;

    private bool doorAnimating = false;
    private BoxCollider bx;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        bx = GetComponentInParent<BoxCollider>();
    }



    private IEnumerator WaitForDoorOpen()
    {
        doorAnimating = true;
        ToggleDoorState();
        yield return new WaitForSeconds(1);
        doorAnimating = false;
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

    private void Update()
    {
        if (player.GetComponent<PlayerDoorRaycast>().doorFound)
        {
            if (Input.GetKeyDown(KeyCode.E) && !doorAnimating && playerInRange)
            {
                StartCoroutine(WaitForDoorOpen());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player In Range");
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

}
