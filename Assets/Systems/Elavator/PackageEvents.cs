using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageEvents : MonoBehaviour
{
    //lists all the package events in the game
    public static PackageEvents packageEvents;
    private void Awake()
    {
        if (packageEvents == null)
        {
            packageEvents = this;
        }

    }

    public event Action OnFloor1Day1Package1;
    public void Floor1Day1Package1Delivered()
    {
        if (OnFloor1Day1Package1 != null)
        {
            OnFloor1Day1Package1();
        }
    }

    public event Action OnFloor1Day1Package2;
    public void Floor1Day1Package2Delivered()
    {
        if (OnFloor1Day1Package2 != null)
        {
            OnFloor1Day1Package2();
        }
    }

    public event Action OnFloor2Day1Package1;
    public void Floor2Day1Package1Delivered()
    {
        if (OnFloor2Day1Package1 != null)
        {
            OnFloor2Day1Package1();
        }
    }

    public event Action OnFloor2Day1Package2;
    public void Floor2Day1Package2Delivered()
    {
        if (OnFloor2Day1Package2 != null)
        {
            OnFloor2Day1Package2();
        }
    }

    public event Action OnFloor3Day1Package1;
    public void Floor3Day1Package1Delivered()
    {
        if (OnFloor3Day1Package1 != null)
        {
            OnFloor3Day1Package1();
        }
    }

    public event Action OnFloor3Day1Package2;
    public void Floor3Day1Package2Delivered()
    {
        if (OnFloor3Day1Package2 != null)
        {
            OnFloor3Day1Package2();
        }
    }

}
