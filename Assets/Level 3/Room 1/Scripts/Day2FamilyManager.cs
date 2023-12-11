using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Day2FamilyManager : MonoBehaviour
{
    [SerializeField] GameObject npc1;//MrsFlowers at door
    [SerializeField] GameObject npc2; //MrsFlowers at kitchen
    //[SerializeField] NPCDialogueHandler npc1DialogueHandler; 
    //[SerializeField] NPCDialogueHandler npc2DialogueHandler; 
    [SerializeField] Doorbell doorbell;
    [SerializeField] PackageLocation package1Location; //package
    [SerializeField] PackageLocation package2Location; //phone


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
           // npc1DialogueHandler.InitSingularDialogue(npc1DialogueHandler.singularDialogue[0]); // 1.Mrs Flowers answers the door
            dialogue1Init= true;
        }

        if (package1Location.isCorrectPackage)
        {
           // npc2DialogueHandler.InitSingularDialogue(npc2DialogueHandler.singularDialogue[1]); // 3.Mrs Flowers asks you to look for her phone
            dialogue2Init = true;
        }

        if (package2Location.isCorrectPackage)
        {
           // npc2DialogueHandler.InitSingularDialogue(npc2DialogueHandler.singularDialogue[2]); // 4.Mrs Flowers thanks you
            dialogue3Init = true;
        }

    }

    public void Dialogue1Confirm()
    {
        npc1.SetActive(false); 
        npc2.SetActive(true);
       // npc2DialogueHandler.InitSingularDialogue(npc2DialogueHandler.singularDialogue[0]); // 2.Mrs Flowers tells player to put package on the table
    }
    
}
