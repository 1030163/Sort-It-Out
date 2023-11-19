using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BenPackageDetection : MonoBehaviour
{
    public string packageName;
    public bool checkPackageName = true; // Add this line
    public UnityEvent executeOnCorrectDelivery;
    public UnityEvent executeOnIncorrectDelivery;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Package"))
        {
            if (!checkPackageName || other.gameObject.name == packageName)
            {
                Debug.Log("About to call function: " + executeOnCorrectDelivery);
                executeOnCorrectDelivery.Invoke();
            }
            else
            {
                Debug.Log("About to call function: " + executeOnIncorrectDelivery);
                executeOnIncorrectDelivery.Invoke();
            }
        }
    }
}
