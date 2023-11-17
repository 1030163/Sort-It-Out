using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;

public class PackageEventManager : MonoBehaviour
{
    public bool [] day1PackageChecklist;
    public static PackageEventManager eventManager;
    public bool day1AllTrue;


    //handles what happens when a PackageEvent is called
    private void Awake()
    {
        if (eventManager == null)
        {
            eventManager = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    private void Start()
    {
        if (PackageEvents.packageEvents != null)
        {
            PackageEvents.packageEvents.OnFloor1Day1Package1 += OnFloor1Day1Package1;
            PackageEvents.packageEvents.OnFloor1Day1Package2 += OnFloor1Day1Package2;
            PackageEvents.packageEvents.OnFloor2Day1Package1 += OnFloor2Day1Package1;
            PackageEvents.packageEvents.OnFloor2Day1Package2 += OnFloor2Day1Package2;
            PackageEvents.packageEvents.OnFloor3Day1Package1 += OnFloor3Day1Package1;
            PackageEvents.packageEvents.OnFloor3Day1Package2 += OnFloor3Day1Package2;

        }
        else
        {
            Debug.LogError("PackageEvents.packageEvents is null. Make sure you have an instance of PackageEvents in your scene.");
        }


    }

    private void Update()
    {
        CheckDay1Completion();


    }

    private void CheckDay1Completion()
    {
        day1AllTrue = !day1PackageChecklist.Any(check => check == false);

        if (day1AllTrue)
        {
            //Day1Complete();
            Debug.Log("All packages for Day 1 successfully delivered");
        }
    }
    private void OnFloor1Day1Package1()
    {
        //Code of what happens when event triggered go here.
        //checks off the package in checklist
        day1PackageChecklist[0] = true;
      

        Debug.Log("Floor 1 Package 1 delivered");
    }

    private void OnFloor1Day1Package2()
    {
        day1PackageChecklist[1] = true;

        Debug.Log("Floor 1 Package 2 delivered");
    }

    private void OnFloor2Day1Package1()
    {
        day1PackageChecklist[2] = true;

        Debug.Log("Floor 2 Package 1 delivered");
    }

    private void OnFloor2Day1Package2()
    {
        day1PackageChecklist[3] = true;

        Debug.Log("Floor 2 Package 2 delivered");
    }

    private void OnFloor3Day1Package1()
    {
        day1PackageChecklist[4] = true;

        Debug.Log("Floor 3 Package 1 delivered");
    }

    private void OnFloor3Day1Package2()
    {
        day1PackageChecklist[5] = true;

        Debug.Log("Floor 3 Package 2 delivered");
    }

}