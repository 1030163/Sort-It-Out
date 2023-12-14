using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Day2UniManager : MonoBehaviour
{
    [SerializeField] GameObject npc1; //Sam at door
    //[SerializeField] NPCDialogueHandler npc1DialogueHandler;
    //[SerializeField] NPCDialogueHandler npc2DialogueHandler;
    [SerializeField] Doorbell doorbell;
    [SerializeField] PackageLocation package1Location; //package
    [SerializeField] DialogueHandler npc1DialogueHandler;
    [SerializeField] DialogueTree[] dialogueTree;
    [SerializeField] NPCDialogue[] singularDialogue;
    [SerializeField] Transform samNewPosition;
    [SerializeField] DoorController door2;
    int keyPress;


    private bool dialogue1Init;
    private bool dialogue2Init;
    private bool dialogue3Init;
    private bool dialogue4Init;
    private bool dialogue5Init;

    private void Start()
    {
        dialogue1Init = false;
        dialogue2Init = false;
        dialogue3Init = false;
        dialogue4Init = false;
        dialogue5Init = false;
    }
    private void Update()
    {
        if (doorbell.isDoorOpen && dialogue1Init == false)
        {
            npc1DialogueHandler.InitSingularDialogue(singularDialogue[0], "Sam Andre", VOICE_TYPE.Masculine);// 1.Sam answers the door
            dialogue1Init = true;
        }
        if (dialogue1Init = true && Input.GetKeyUp(KeyCode.E))
            {
            keyPress++;
        }
        if (dialogue2Init == false && keyPress == 2)
        {
            npc1.transform.position = samNewPosition.position;
            door2.DoorStateChange();
            npc1DialogueHandler.InitDialogueTree(dialogueTree[0], "Sam Andre", VOICE_TYPE.Masculine);// 2.Sam shows the basketball hoop - instructions - hold down left mouse button to throw
            dialogue2Init = true;
        }

        

        if (package1Location.isCorrectPackage && dialogue3Init == false)
        {
            npc1DialogueHandler.InitDialogueTree(dialogueTree[1], "Sam Andre", VOICE_TYPE.Masculine); // 3.Sam cheers and player tells about mr flowers
            dialogue3Init = true;
        }

    }

}
