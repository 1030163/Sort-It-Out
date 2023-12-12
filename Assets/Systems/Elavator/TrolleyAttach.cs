using UnityEngine;

public class TrolleyAttach : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;   
    private bool isPlayerHere;
    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isPlayerHere)
        {
            AttachTrolley();
        }

    }

    private void AttachTrolley()
    {
        transform.parent.parent = playerTransform; // Attach the object to the player
        //transform.parent.rotation = Quaternion.identity;
        transform.rotation = Quaternion.LookRotation(playerTransform.position - transform.position, Vector3.up) * initialRotation;

        transform.parent.localPosition = new Vector3 (0,-1.2f,4f);
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
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
