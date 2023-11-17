using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLocations : MonoBehaviour
{
    public GameObject Ghost;
    public Vector3 Location1;
    public Vector3 Location2;
    public Vector3 Location3;
    public string currentGhostLocation;

    void Start()
    {
        currentGhostLocation = "Location1";
        Ghost.transform.position = Location1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");
            switch (currentGhostLocation)
            {
                case "Location1":
                    Ghost.transform.position = Location2;
                    currentGhostLocation = "Location2";
                    break;
                case "Location2":
                    Ghost.transform.position = Location3;
                    currentGhostLocation = "Location3";
                    break;
                case "Location3":
                    
                    break;
                default:
                    Debug.Log("something went wrong");
                    break;
            }
        }
    } 
}
