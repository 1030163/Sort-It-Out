using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuijaBoard : MonoBehaviour
{
    public GameObject Puck;
    public Vector3 Neutral;
    public Vector3 R;
    public Vector3 I;
    public Vector3 N;
    public Vector3 G;
    public string currentPuckLocation;
    public float speed = 1.0f;
    public float smoothTime = 0.3f;

    private bool isActivated = false;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        isActivated = false;
    }
    private void OnTriggerEnter(Collider Player)
    {
        if(isActivated == false)
        {
            StartCoroutine(MovePuck());
            isActivated = true;
        } 
    }

    IEnumerator MovePuck()
    {
        Vector3[] positions = new Vector3[] { Neutral, R, I, N, G, Neutral };

        while (true) // Infinite loop to keep the coroutine running
        {
            // Move to Neutral initially and after completing a cycle
            yield return StartCoroutine(MoveTowardsPosition(Neutral));
            // Wait for 3 seconds after reaching Neutral
            yield return new WaitForSeconds(1f);

            // Go through each position after Neutral
            foreach (Vector3 newPosition in positions)
            {
                // Wait for 1 second before moving to the next position
                yield return new WaitForSeconds(1f);

                // Coroutine to move towards the new position
                yield return StartCoroutine(MoveTowardsPosition(newPosition));
            }

            // After reaching the last position (G), wait for 1 second before moving back to Neutral
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator MoveTowardsPosition(Vector3 targetPosition)
    {
        // Continue looping until the position is approximately reached.
        while (Vector3.Distance(Puck.transform.localPosition, targetPosition) > 0.01f)
        {
            Puck.transform.localPosition = Vector3.SmoothDamp(Puck.transform.localPosition, targetPosition, ref velocity, smoothTime, speed, Time.deltaTime);
            yield return null; // Wait for the next frame
        }

        // Directly set the position to ensure it is exactly at the target location after stopping.
        Puck.transform.localPosition = targetPosition;
    }
}
