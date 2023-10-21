using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageLocation : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    public bool isPackage;
    public string packageName;
    // Start is called before the first frame update
    void Start()
    {

>>>>>>> Systems
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Package"))
        {
<<<<<<< HEAD
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
=======
            isPackage = true;
            packageName = other.gameObject.name;
>>>>>>> Systems
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Package") && other.gameObject.name == packageName)
        {
<<<<<<< HEAD
            isAnyPackage = false;
=======
            isPackage = false;
>>>>>>> Systems
            packageName = "";
        }
    }
}
