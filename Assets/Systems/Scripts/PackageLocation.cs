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
    // Start is called before the first frame update
    void Start()
    {
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
            }
            else
            {
                isCorrectPackage = false;
            }

            if (isCorrectPackage)
            {
                print("You Did it!! Woo!! PAckage delivered!!!!!!!");
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
