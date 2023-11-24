using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HermitDetection : MonoBehaviour
{
    public GameObject RadioPackage;

    private void OnTriggerEnter(Collider Package)
    {
        if(Package.name == "RadioPackage")
        {
            RadioPackage.GetComponent<RadioAudio>().isInsideApart = true;
        }
    }
}
