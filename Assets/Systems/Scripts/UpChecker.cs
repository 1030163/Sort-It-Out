using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpChecker : MonoBehaviour
{
    [Header("Up Sticker Outputs")]
    public bool isUpright;
    [Header("Up Sticker Restraints")]
    public float rotationLimit = 15f;

    GameObject thePointer;

    bool xCheck;
    bool zCheck;
    // Start is called before the first frame update
    void Start()
    {
        thePointer = transform.Find("UpPointer").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Clamp(Mathf.DeltaAngle(thePointer.transform.rotation.eulerAngles.x, 0f), -rotationLimit, rotationLimit) == Mathf.DeltaAngle(thePointer.transform.rotation.eulerAngles.x, 0f))
        {
            xCheck = true;
        }
        else
        {
            xCheck = false;
        }
        if (Mathf.Clamp(Mathf.DeltaAngle(thePointer.transform.rotation.eulerAngles.z, 0f), -rotationLimit, rotationLimit) == Mathf.DeltaAngle(thePointer.transform.rotation.eulerAngles.z, 0f))
        {
            zCheck = true;
        }
        else
        {
            zCheck = false;
        }

        if (xCheck && zCheck)
        {
            isUpright = true;

        }
        else
        {
            isUpright = false;

        }
    }
}
