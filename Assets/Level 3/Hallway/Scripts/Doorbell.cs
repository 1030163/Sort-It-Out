using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Doorbell : MonoBehaviour
{
    [SerializeField] TextMeshPro interactionText;
    [SerializeField] GameObject door;
    [SerializeField] PackageLocation packageDelivery;
    private void OnTriggerEnter(Collider other)
    {
        interactionText.gameObject.SetActive(true);
        if (packageDelivery.isCorrectPackage)
        {
            WaitCoroutine(5f);
            door.SetActive(true);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (packageDelivery.isCorrectPackage)
        {
            WaitCoroutine(5f);
            door.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactionText.gameObject.SetActive(false);
    }

    public void RingDoorbell ()
    {
        WaitCoroutine(2f);
        door.SetActive(false);
    }

    IEnumerator WaitCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
