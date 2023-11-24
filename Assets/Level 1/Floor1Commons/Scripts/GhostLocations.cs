using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLocations : MonoBehaviour
{
    public GameObject Ghost;
    public GameObject RadioPackage;
    public Vector3 Location1;
    public Vector3 Location2;
    public Vector3 Location3;
    public string currentGhostLocation;

    void Start()
    {
        currentGhostLocation = "Location1";
        Ghost.transform.localPosition = Location1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Package"))
        {
            Debug.Log("Player entered the trigger zone.");
            switch (currentGhostLocation)
            {
                case "Location1":
                    Ghost.transform.localPosition = Location2;
                    currentGhostLocation = "Location2";
                    RadioPackage.GetComponent<RadioAudio>().playDuration = 2f;
                    break;
                case "Location2":
                    Ghost.transform.localPosition = Location3;
                    currentGhostLocation = "Location3";
                    RadioPackage.GetComponent<RadioAudio>().playDuration = 3.5f;
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
