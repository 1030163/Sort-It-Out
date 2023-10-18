using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpChecker : MonoBehaviour
{
    public GameObject thePointer;
    public Vector3 rotationLimit = new Vector3(0f, 0f, 0f);

    public bool xCheck;
    public bool zCheck;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Clamp(Mathf.DeltaAngle(thePointer.transform.rotation.eulerAngles.x, 0f), -15f, 15f) == Mathf.DeltaAngle(thePointer.transform.rotation.eulerAngles.x, 0f))
        {
            xCheck = true;
        }
        else
        {
            xCheck = false;
        }
        if (Mathf.Clamp(Mathf.DeltaAngle(thePointer.transform.rotation.eulerAngles.z, 0f), -15f, 15f) == Mathf.DeltaAngle(thePointer.transform.rotation.eulerAngles.z, 0f))
        {
            zCheck = true;
        }
        else
        {
            zCheck = false;
        }

        if (xCheck && zCheck)
        {
            Debug.Log("safe");

        }
        else
        {
            Debug.Log("Unsafe");

        }
    }
}
