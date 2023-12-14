using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Day2UniManager : MonoBehaviour
{
    [SerializeField] GameObject npc1; //Sam at door
    [SerializeField] GameObject npc2; //Sam in room
    //[SerializeField] NPCDialogueHandler npc1DialogueHandler;
    //[SerializeField] NPCDialogueHandler npc2DialogueHandler;
    [SerializeField] Doorbell doorbell;
    [SerializeField] PackageLocation package1Location; //package
    [SerializeField] DialogueHandler npc1DialogueHandler;
    [SerializeField] DialogueTree[] dialogueTree;
    [SerializeField] NPCDialogue[] singularDialogue;


    private bool dialogue1Init;
    private bool dialogue2Init;

    private void Start()
    {
        dialogue1Init = false;
        dialogue2Init = false;
    }
    private void Update()
    {
        if (doorbell.isDoorOpen && dialogue1Init == false)
        {
            npc1DialogueHandler.InitSingularDialogue(singularDialogue[0], "Sam Andre", VOICE_TYPE.Masculine);// 1.Sam answers the door
            dialogue1Init = true;
        }

        if (package1Location.isCorrectPackage)
        {
            npc1DialogueHandler.InitSingularDialogue(singularDialogue[2], "Sam Andre", VOICE_TYPE.Masculine); // 3.Sam cheers
            dialogue2Init = true;
        }

    }

    public void Dialogue1Confirm1()
    {
        npc1DialogueHandler.InitSingularDialogue(singularDialogue[1], "Sam Andre", VOICE_TYPE.Masculine);// 2.Sam shows the basketball hoop - instructions - hold down left mouse button to throw
    }

    public void Dialogue1Confirm2()
    {
        npc1DialogueHandler.InitSingularDialogue(singularDialogue[3], "Sam Andre", VOICE_TYPE.Masculine);// 4. Sam laments about Mr Flowers
    }

}
