using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorRaycast : MonoBehaviour
{
    private float raycastDistance = 1f;
    public bool doorFound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForDoor();
    }

    void CheckForDoor()
    {
        Vector3 playerPosition = transform.position;
        Vector3 playerForward = transform.forward;

        Ray ray = new Ray(playerPosition, playerForward);

        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Door"))
            {
                doorFound = true;
            }
            else
            {
                doorFound = false;
            }
        }
    }
}
