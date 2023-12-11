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

    private bool triggeredOnce1 = false;
    private bool triggeredOnce2 = false;

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
        
        if (triggeredOnce1 == false)
        {
            Debug.Log("Funtion: RadioPackageDelivered() called");

            //SpareRoomDoor.GetComponent<ModifiedDoorController>().ScriptedToggleDoorState();
            SpareRoomDoor.GetComponent<DoorController>().AutomaticDoor();
            SpareRoomDoor.GetComponent<AudioSource>().Play();
            triggeredOnce1 = true;
        }

    }

    public void BothPackagesCorrectlyDelivered()
    {
        
        if (triggeredOnce2 == false)
        {
            Debug.Log("Funtion: BothPackagesCorrectlyDelivered() called");
            //SurvRoomDoor.GetComponent<ModifiedDoorController>().ScriptedToggleDoorState();
            SurvRoomDoor.GetComponent<DoorController>().AutomaticDoor();
            SurvRoomDoor.GetComponent<AudioSource>().Play();
            SurvRoomLight.SetActive(false);
            StartCoroutine(PlaySlamSound(SurvWardrobe));
            triggeredOnce2 = true;
        }

    }

    IEnumerator PlaySlamSound(AudioSource audioSource)
    {
        if (audioSource == null) yield break; // Exit if no audio source is provided
        yield return new WaitForSeconds(1);
        audioSource.Play();
    }
}
