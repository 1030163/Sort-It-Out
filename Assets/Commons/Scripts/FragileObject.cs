using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FragileObject : MonoBehaviour
{
    [Header("Break Limits")]
    [Tooltip("This value is \'how hard\' the object needs to hit a surface to break")]
    public float howFastToBreak = 10f;
    [Space]
    [Tooltip("If true this object needs the Shakable Object script attached as well, then for the break event title to be called within that component.")]
    public bool shakeToBreak;
    [Tooltip("This is the title of the break event to be called within the Shake Script. \"Call Break!\" by default.")]
    public string breakEventTitle = "Call Break!";

    [SerializeField]
    ShakeableObject shakeComp;

    [Space]
    [Space]
    [Header("Output Values")]
    public bool broken;

    private void Start()
    {
        if (shakeToBreak && GetComponent<ShakeableObject>())
        {
            shakeComp = GetComponent<ShakeableObject>();

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (howFastToBreak < collision.relativeVelocity.magnitude)
        {
            OnBreakEvent();
        }
    }

    void OnBreakEvent()
    {
        broken = true;
    }

    public void ShakeCheck()
    {
        if (!broken && shakeComp.currentShakeEvent == breakEventTitle)
        {
            print(shakeComp.currentShakeEvent + " & " + breakEventTitle);
            OnBreakEvent();
        }
    }

}


