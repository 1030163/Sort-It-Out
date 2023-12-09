using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool openInside;
    private bool isOpen = false;

    public bool hasPermission = true;
    private Animator animator;

    //private GameObject player;
    //private bool playerInRange = false;

    private bool doorAnimating = false;
    private BoxCollider bx;

    //private float raycastDistance = 1f;
    public bool doorFound;


    public bool automaticDoor;

    void Start()
    {
        animator = GetComponent<Animator>();
        //player = GameObject.FindGameObjectWithTag("Player");
        bx = GetComponentInChildren<BoxCollider>();
    }

    public void DoorStateChange()
    {
        if (!doorAnimating)
        {
            StartCoroutine(WaitForDoorOpen());
        }
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

    public void AutomaticDoor()
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && automaticDoor)
        {
            AutomaticDoor();
        }
        //if (doorFound)
        //{
        //    if (Input.GetKeyDown(KeyCode.E) && !doorAnimating)
        //    {
        //        StartCoroutine(WaitForDoorOpen());
        //    }
        //}
        //CheckForDoor();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Collision detected");
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("Player In Range");
    //        playerInRange = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        playerInRange = false;
    //    }
    //}


    //void CheckForDoor()
    //{
    //    Vector3 playerPosition = player.transform.position;
    //    Vector3 playerForward = player.transform.forward;

    //    Ray ray = new Ray(playerPosition, playerForward);

    //    if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
    //    {
    //        if (hit.collider.CompareTag("Door"))
    //        {
    //            doorFound = true;
    //        }
    //        else
    //        {
    //            doorFound = false;
    //        }
    //    }
    //    else
    //    {
    //        doorFound = false;
    //    }
    //}


}
