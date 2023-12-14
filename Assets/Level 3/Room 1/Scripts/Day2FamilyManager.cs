using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Day2FamilyManager : MonoBehaviour
{
    [SerializeField] GameObject npc; //MrsFlowers at kitchen
    //[SerializeField] NPCDialogueHandler npc1DialogueHandler; 
    //[SerializeField] NPCDialogueHandler npc2DialogueHandler; 
    [SerializeField] Doorbell doorbell;
    [SerializeField] PackageLocation package1Location; //package
    [SerializeField] PackageLocation package2Location; //phone
    [SerializeField] DialogueHandler npc1DialogueHandler;
    [SerializeField] DialogueTree[] dialogueTree;
    [SerializeField] NPCDialogue[] singularDialogue;

    private bool dialogue1Init;
    private bool dialogue2Init;
    private bool dialogue3Init;

    private void Start()
    {
        dialogue1Init = false;
        dialogue2Init = false;
        dialogue3Init = false;
    }
    private void Update()
    {
        if (doorbell.isDoorOpen && dialogue1Init == false)
        {
            npc1DialogueHandler.InitDialogueTree(dialogueTree[0], "Nancy Flower", VOICE_TYPE.Feminine); // 1.Mr Flowers answers the door & tells player to put package on the table
            dialogue1Init = true;
        }

        if (package1Location.isCorrectPackage && dialogue2Init == false)
        {
            npc1DialogueHandler.InitSingularDialogue(singularDialogue[0], "Nancy Flower", VOICE_TYPE.Feminine); // 2.Mrs Flowers asks you to look for her phone
            dialogue2Init = true;
        }

        if (package2Location.isCorrectPackage && dialogue3Init == false)
        {
            npc1DialogueHandler.InitSingularDialogue(singularDialogue[1], "Nancy Flower", VOICE_TYPE.Feminine);// 3.Mrs Flowers thanks you
            dialogue3Init = true;
        }

    }
}
