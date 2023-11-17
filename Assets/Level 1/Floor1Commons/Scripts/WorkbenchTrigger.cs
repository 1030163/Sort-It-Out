using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchTrigger : MonoBehaviour
{
    private bool triggeredOnce = false;
    public void Start()
    {
        triggeredOnce = false;
    }
    public void OnTriggerExit(Collider Player)
    {
        if (triggeredOnce == false)
        {
            HermitGameManager.instance.StartInstructionsUnderDoor();
            triggeredOnce = true;
        }
        
    }
}
