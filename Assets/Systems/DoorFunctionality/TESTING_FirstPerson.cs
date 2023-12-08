using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTING_FirstPerson : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;

    private void Update()
    {
        // Move the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveAmount = moveDirection * movementSpeed * Time.deltaTime;
        transform.Translate(moveAmount);

        // Rotate the player based on mouse input (left and right only)
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 rotation = new Vector3(0f, mouseX, 0f) * mouseSensitivity;
        transform.Rotate(rotation);
    }
}
