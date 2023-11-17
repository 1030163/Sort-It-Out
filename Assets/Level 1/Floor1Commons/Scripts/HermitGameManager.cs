using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HermitGameManager : MonoBehaviour
{
    public static HermitGameManager instance;
    public GameObject WorkbenchTrigger;
    public GameObject TrueInstructions;

    public GameObject SpareRoomDoor;
    public GameObject SurvRoomDoor;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void StartInstructionsUnderDoor()
    {
        TrueInstructions.GetComponent<TrueInstructions>().InstructionsUnderDoor();
    }

    public void RadioPackageDelivered()
    {
        SpareRoomDoor.SetActive(false);
    }

    public void BothPackagesCorrectlyDelivered()
    {
        SurvRoomDoor.SetActive(false);
    }
}
