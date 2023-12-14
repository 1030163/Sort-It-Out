using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Day1FamilyManager : MonoBehaviour
{
    [SerializeField] GameObject npc; //MrFlowers at door
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
           npc1DialogueHandler.InitSingularDialogue(singularDialogue[0], "Tim Flower", VOICE_TYPE.Masculine); // 1.Mr Flowers answers the door
            dialogue1Init= true;
        }

        if (package1Location.isCorrectPackage && dialogue2Init == false)
        {
            npc1DialogueHandler.InitDialogueTree(dialogueTree[0], "Tim Flower", VOICE_TYPE.Masculine); // 1.Mr Flowers answers the door
            dialogue2Init = true;
        }

    }

    public void Dialogue1Confirm()
    {
        //npc.SetActive(true);
       // npc2DialogueHandler.InitSingularDialogue(npc2DialogueHandler.singularDialogue[0]); // 2.Mrs Flowers tells player to put package on the table
    }
    
}
