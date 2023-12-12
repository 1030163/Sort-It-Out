using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyDetach : MonoBehaviour
{
    [SerializeField] private Transform attachPoint;
    private bool isPlayerHere;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && isPlayerHere)
        {
            DetachTrolley();
        }
    }
    private void DetachTrolley()
    {
        transform.parent.parent = null; // Detach the object from the player
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attachPoint = other.transform;
            isPlayerHere = true;
        }
    }
}
