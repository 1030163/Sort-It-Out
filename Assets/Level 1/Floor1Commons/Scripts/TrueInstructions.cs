using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueInstructions : MonoBehaviour
{
    public GameObject InstructionsObject;
    public Vector3 Location1;
    public Vector3 Location2;
    public float moveSpeed = 5f;

    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 1.0f; // Adjust this time to control the acceleration and deceleration

    public void Start()
    {
        InstructionsObject = gameObject;
        InstructionsObject.transform.localPosition = Location1;
    }
    public void InstructionsUnderDoor()
    {
        StartCoroutine(MoveInstructions());
    }

    IEnumerator MoveInstructions()
    {
        float elapsed = 0.0f;
        float distance = Vector3.Distance(Location1, Location2);
        float currentSpeed = 0.0f;
        InstructionsObject.GetComponent<AudioSource>().Play();
        while (elapsed < smoothTime)
        {
            elapsed += Time.deltaTime;
            currentSpeed = Mathf.Lerp(0, moveSpeed, elapsed / smoothTime); // Accelerate over time
            float step = currentSpeed * Time.deltaTime;

            if (step > distance)
            {
                step = distance; // Avoid overshooting
            }

            InstructionsObject.transform.localPosition = Vector3.MoveTowards(InstructionsObject.transform.localPosition, Location2, step);
            distance -= step;

            if (distance <= 0.0f)
            {
                break; // Stop the coroutine if the object has reached the destination
            }

            yield return null;
        }
        
        InstructionsObject.transform.localPosition = Location2; // Ensure the object is exactly at Location2
    }

}
