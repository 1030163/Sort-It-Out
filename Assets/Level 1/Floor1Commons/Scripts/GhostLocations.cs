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

    public GameObject PackageDeliveryLocation;

    void Start()
    {
        RadioPackage = GameObject.Find("Terrance_Radio");
        PackageDeliveryLocation = GameObject.Find("PlacePackageHereRADIO");
        currentGhostLocation = "Location1";
        Ghost.transform.localPosition = Location1;
        PackageDeliveryLocation.SetActive(false);
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
                    Debug.Log("Ghost moved to location 2");
                    break;
                case "Location2":
                    Ghost.transform.localPosition = Location3;
                    currentGhostLocation = "Location3";
                    RadioPackage.GetComponent<RadioAudio>().playDuration = 3.5f;
                    Debug.Log("Ghost moved to location 3");
                    PackageDeliveryLocation.SetActive(true);
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
