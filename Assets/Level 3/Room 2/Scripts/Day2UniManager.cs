using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Day2UniManager : MonoBehaviour
{
    [SerializeField] GameObject npc1; //Sam at door
    [SerializeField] GameObject npc2; //Sam in room
    [SerializeField] NPCDialogueHandler npc1DialogueHandler;
    [SerializeField] NPCDialogueHandler npc2DialogueHandler;
    [SerializeField] Doorbell doorbell;
    [SerializeField] PackageLocation package1Location; //package


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
            npc1DialogueHandler.InitSingularDialogue(npc1DialogueHandler.singularDialogue[0]); // 1.Sam answers the door
            dialogue1Init= true;
        }

        if (package1Location.isCorrectPackage)
        {
            npc2DialogueHandler.InitSingularDialogue(npc2DialogueHandler.singularDialogue[1]); // 3.Sam cheers
            dialogue2Init = true;
        }

    }

    public void Dialogue1Confirm()
    {
        npc1.SetActive(false); 
        npc2.SetActive(true);
        npc2DialogueHandler.InitSingularDialogue(npc2DialogueHandler.singularDialogue[0]); // 2.Sam shows the basketball hoop
    }
    
}
