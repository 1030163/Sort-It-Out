using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PackageManager : MonoBehaviour
{
    //Manages all the package deliveries in the scene
    [Header("Package Delivery GameObjects")]
    [SerializeField] PackageLocation package1Delivery;
    [SerializeField] bool package1Delivered = false;
    [SerializeField] PackageLocation package2Delivery;
    [SerializeField] bool package2Delivered = false;
    [SerializeField] PackageEventManager eventManager;
    [SerializeField] GameObject[] packageObjects;


    private void Start()
    {
        if (eventManager == null)
        {
            eventManager = FindObjectOfType<PackageEventManager>();
        }

        if (eventManager != null)
        {
            //disables Package Checker if Package has already been delivered.

            for (int i = 0; i < packageObjects.Length;i++) 
            { 
            if (eventManager.day1PackageChecklist[i])
                {
                    packageObjects[i].SetActive(false);
                }
            }
            //disable package checker border
        }
    }
    void Update()
    {
        //if the Package Deliver Location detects the correct package then it calls the desired PackageEvent.
        if (package1Delivery.isCorrectPackage && !package1Delivered && SceneManager.GetActiveScene().buildIndex == 3)
        {
            PackageEvents.packageEvents.Floor1Day1Package1Delivered();
            package1Delivered = true;
            package1Delivery.gameObject.SetActive(false);
        }

        if (package2Delivery.isCorrectPackage && !package2Delivered && SceneManager.GetActiveScene().buildIndex == 3)
        {
            PackageEvents.packageEvents.Floor1Day1Package2Delivered();
            package2Delivered = true;
            package2Delivery.gameObject.SetActive(false);
        }

        if (package1Delivery.isCorrectPackage && !package1Delivered && SceneManager.GetActiveScene().buildIndex == 4)
        {
            PackageEvents.packageEvents.Floor2Day1Package1Delivered();
            package1Delivered = true;
            package1Delivery.gameObject.SetActive(false);
        }

        if (package2Delivery.isCorrectPackage && !package2Delivered && SceneManager.GetActiveScene().buildIndex == 4)
        {
            PackageEvents.packageEvents.Floor2Day1Package2Delivered();
            package2Delivered = true;
            package2Delivery.gameObject.SetActive(false);
        }

        if (package1Delivery.isCorrectPackage && !package1Delivered && SceneManager.GetActiveScene().buildIndex == 5)
        {
            PackageEvents.packageEvents.Floor3Day1Package1Delivered();
            package1Delivered = true;
            package1Delivery.gameObject.SetActive(false);
        }

        if (package2Delivery.isCorrectPackage && !package2Delivered && SceneManager.GetActiveScene().buildIndex == 5)
        {
            PackageEvents.packageEvents.Floor3Day1Package2Delivered();
            package2Delivered = true;
            package2Delivery.gameObject.SetActive(false);
        }
    }
}
