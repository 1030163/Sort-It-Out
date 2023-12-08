using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationMark : MonoBehaviour
{
    // Start is called before the first frame update

    private float bobSpeed = 1.3f;
    private float bobHeight = 0.08f;
    private float rotateSpeed = 30f;

    private Vector3 originalPosition;
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = originalPosition + new Vector3(0f, yOffset, 0f);

        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
