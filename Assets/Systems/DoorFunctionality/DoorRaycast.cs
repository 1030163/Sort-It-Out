using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    private float rayLength = 1.5f;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayername = null;

    private DoorController doorControl;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;
    [SerializeField] private Image crosshair = null;
    private bool isCrossHairActive;
    private bool doOnce;

    private const string interactableTag = "Door";

    private void Start()
    {
        //Adds a crosshair to the scene and references it
        //max was 'ere
        GameObject crosshairCanvas = Resources.Load<GameObject>("CrosshairCanvas");
        GameObject inScene = Instantiate(crosshairCanvas);
        crosshair = inScene.transform.GetChild(0).GetComponent<Image>();
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayername) | layerMaskInteract.value;

        

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {

            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    doorControl = hit.collider.gameObject.GetComponent<DoorController>();
                    CrosshairChange(true);
                }
                isCrossHairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    doorControl.DoorStateChange();
                }
                UIManager.controlPromptActive = true;
                UIManager.controlNumber = 1;
            }
            //needed this case because if you hit anything it wouldn't turn off the crosshair
            //max was 'ere
            else
            {
                if (isCrossHairActive)
                {
                    CrosshairChange(false);
                    doOnce = false;
                }
                

            }
        }
        else
        {
            if (isCrossHairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }

            UIManager.controlPromptActive = false;
            UIManager.controlNumber = 0;
        }

       

    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrossHairActive = false;
        }
    }
}
