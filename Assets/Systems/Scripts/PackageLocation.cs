using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageLocation : MonoBehaviour
{
    [Header("Package Information")]
    public bool isAnyPackage;
    public bool isCorrectPackage;
    public string packageName;

    [Header("Package That Goes Here?")]
    public string intendedPackageName;

    [Header("Graphics")]
    public bool showOutline;
    public bool packageDisappears;

    [Header("Successful Delivery")]
    public string printOnSuccess;

    // Start is called before the first frame update
    void Start()
    {
        isCorrectPackage = false;

        if (!showOutline)
        {
            MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in meshRenderers)
            {
                renderer.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Checks string against package name and checks it off the list

        if (intendedPackageName == "F1D1P1" && isCorrectPackage)
        {
            PackageEvents.packageEvents.F1D1P1Delivered();
            this.gameObject.SetActive(false);
        }

        if (intendedPackageName == "F1D1P2" && isCorrectPackage)
        {
            PackageEvents.packageEvents.F1D1P2Delivered();
            this.gameObject.SetActive(false);
        }

        if (intendedPackageName == "F2D1P1" && isCorrectPackage)
        {
            PackageEvents.packageEvents.F2D1P1Delivered();
            this.gameObject.SetActive(false);
        }

        if (intendedPackageName == "F2D1P2" && isCorrectPackage)
        {
            PackageEvents.packageEvents.F2D1P2Delivered();
            this.gameObject.SetActive(false);
        }

        if (intendedPackageName == "F3D1P1" && isCorrectPackage)
        {
            PackageEvents.packageEvents.F3D1P1Delivered();
            this.gameObject.SetActive(false);
        }

        if (intendedPackageName == "F3D1P2" && isCorrectPackage)
        {
            PackageEvents.packageEvents.F3D1P2Delivered();
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Package"))
        {
            isAnyPackage = true;
            packageName = other.gameObject.name;
            if (packageName == intendedPackageName)
            {
                isCorrectPackage = true;
                if (packageDisappears)
                {
                    other.gameObject.SetActive(false);


                }
            }
            else
            {
                isCorrectPackage = false;
            }

            if (isCorrectPackage)
            {
                print(printOnSuccess);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Package") && other.gameObject.name == packageName)
        {
            isAnyPackage = false;
            packageName = "";
        }
    }
}
