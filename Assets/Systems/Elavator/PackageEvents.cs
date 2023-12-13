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

    public event Action OnF1D1P1;
    public void F1D1P1Delivered()
    {
        if (OnF1D1P1 != null)
        {
            OnF1D1P1();
        }
    }

    public event Action OnF1D1P2;
    public void F1D1P2Delivered()
    {
        if (OnF1D1P2 != null)
        {
            OnF1D1P2();
        }
    }

    public event Action OnF2D1P1;
    public void F2D1P1Delivered()
    {
        if (OnF2D1P1 != null)
        {
            OnF2D1P1();
        }
    }

    public event Action OnF2D1P2;
    public void F2D1P2Delivered()
    {
        if (OnF2D1P2 != null)
        {
            OnF2D1P2();
        }
    }

    public event Action OnF3D1P1;
    public void F3D1P1Delivered()
    {
        if (OnF3D1P1 != null)
        {
            OnF3D1P1();
        }
    }

    public event Action OnF3D1P2;
    public void F3D1P2Delivered()
    {
        if (OnF3D1P2 != null)
        {
            OnF3D1P2();
        }
    }

    public event Action OnSaveTrolleyPackageState;
    public void SaveTrolleyPackageState()
    {
        if (OnSaveTrolleyPackageState != null)
        {
            OnSaveTrolleyPackageState();
        }
    }

    

}
