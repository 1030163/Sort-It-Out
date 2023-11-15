using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchTrigger : MonoBehaviour
{
    public void OnTriggerExit(Collider Player)
    {
        HermitGameManager.instance.StartInstructionsUnderDoor();
    }
}
