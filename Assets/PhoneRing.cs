using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneRing : MonoBehaviour
{
    [SerializeField] PackageLocation firstDelivery;
    [SerializeField] PackageLocation phoneDelivery;
    [SerializeField] AudioSource phoneSound;

    // Update is called once per frame
    void Update()
    {
        if (firstDelivery.isCorrectPackage)
        {
            phoneSound.Play();
        }

        //if picked up, audioSource.Stop();

        //deliver phone
        if (firstDelivery.isCorrectPackage)
        {
            //quest done
        }
    }


}
