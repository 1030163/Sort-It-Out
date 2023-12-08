using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyAttach : MonoBehaviour
{
    [SerializeField] Transform attachPoint;
    bool isAttached;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 corresponds to the left mouse button
        {
            ToggleTrolleyAttachment();
        }
    }

    void ToggleTrolleyAttachment()
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

    void AttachTrolley()
    {
        if (this.gameObject != null)
        {
            this.gameObject.transform.parent = attachPoint; // Attach the object to the player
            this.gameObject.transform.localPosition = new Vector3(0, 0, 0.5f); // Reset local position
            isAttached = true;
        }
    }

    void DetachTrolley()
    {
        if (this.gameObject != null)
        {
            this.gameObject.transform.parent = null; // Detach the object from the player
            isAttached = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player"))
        {
            attachPoint = other.transform;
        }
    }
}
