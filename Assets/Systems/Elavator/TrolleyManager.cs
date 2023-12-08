using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyManager : MonoBehaviour
{
    PackageEventManager packageEventManager;
    [SerializeField] GameObject[] day1Packages;
    [SerializeField] GameObject[] day2Packages;
    [SerializeField] Transform attachPoint;
    bool isDay1;
    bool isAttached;
    List<GameObject> packagesInTrolley;

    void Awake()
    {
        packageEventManager = FindObjectOfType<PackageEventManager>();
    }

    private void Start()
    {

        //if (packageToInstantiate != null && packageSpawnPoint != null)
        {
        //    Instantiate(prefabToInstantiate, packageSpawnPoint.position, packageSpawnPoint.rotation);
        }

    }

    //if player is in trigger
    //player left clicks
    //add package to trolley list
    //place package in trolley


    //if package is in trolley, on floor start, spawn the package

}
