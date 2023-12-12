using UnityEngine;

public class TrolleyAttach : MonoBehaviour
{
    [SerializeField] private Transform attachPoint;
    private bool isAttached;   
    private bool isPlayerHere;   
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isPlayerHere)
        {
            AttachTrolley();
        }

        if (Input.GetMouseButtonDown(1) && isPlayerHere)
        {
            DetachTrolley();
        }
    }

    private void ToggleTrolleyAttachment()
    {
        if (isAttached)
        {
            DetachTrolley();
        }
        else
        {
            AttachTrolley();
        }
    }

    private void AttachTrolley()
    {
        transform.parent = attachPoint; // Attach the object to the player
        transform.parent.rotation = Quaternion.identity;
        isAttached = true;
    }

    private void DetachTrolley()
    {
        transform.parent.parent = null; // Detach the object from the player
        isAttached = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attachPoint = other.transform;
            isPlayerHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerHere = false;
        }
    }
}
