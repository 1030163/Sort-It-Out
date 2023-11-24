using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HermitGameManager : MonoBehaviour
{
    public static HermitGameManager instance;
    public GameObject WorkbenchTrigger;
    public GameObject TrueInstructions;

    public GameObject SpareRoomDoor;
    
    public GameObject SurvRoomDoor;
    public AudioSource SurvWardrobe;
    public GameObject SurvRoomLight;

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
        Debug.Log("Funtion: StartInstructionsUnderDoor() called");
        TrueInstructions.GetComponent<TrueInstructions>().InstructionsUnderDoor();
    }

    public void RadioPackageDelivered()
    {
        Debug.Log("Funtion: RadioPackageDelivered() called");
        //SpareRoomDoor.GetComponent<ModifiedDoorController>().hasPermission = true;
        SpareRoomDoor.GetComponent<ModifiedDoorController>().ScriptedToggleDoorState();
        //SpareRoomDoor.GetComponent<ModifiedDoorController>().hasPermission = false;
    }

    public void BothPackagesCorrectlyDelivered()
    {
        Debug.Log("Funtion: BothPackagesCorrectlyDelivered() called");
        SurvRoomDoor.GetComponent<ModifiedDoorController>().ScriptedToggleDoorState();
        SurvRoomLight.SetActive(false);
        StartCoroutine(PlaySlamSound(SurvWardrobe));
    }

    IEnumerator PlaySlamSound(AudioSource audioSource)
    {
        if (audioSource == null) yield break; // Exit if no audio source is provided
        yield return new WaitForSeconds(1);
        audioSource.Play();
    }
}
