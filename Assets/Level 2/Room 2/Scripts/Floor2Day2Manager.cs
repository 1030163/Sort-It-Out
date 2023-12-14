using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor2Day2Manager : MonoBehaviour
{

    [SerializeField] DialogueHandler dialogueHandler;

    public DialogueTree[] dialogueTrees;
    public NPCDialogue[] singularDialogue;
    [SerializeField] Doorbell doorbell;
    [SerializeField] Doorbell toneysDoorbell;
    [SerializeField] GameObject triggerZoneWesley;
    [SerializeField] GameObject triggerZoneToney;
    [SerializeField] GameObject theArts;

    bool bMVaseDelivered;
    bool metWesley;
    bool wesleyPaintsDelivered;
    bool metToney;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorbell.isDoorOpen && !metWesley)
        {
            dialogueHandler.InitDialogueTree(dialogueTrees[0], "Wesley Stashwell", VOICE_TYPE.Masculine); //dialogue for door open
            metWesley = true;
        }

        if (toneysDoorbell.isDoorOpen && !metToney)
        {
            dialogueHandler.InitDialogueTree(dialogueTrees[1], "Toney Immaculate", VOICE_TYPE.Masculine); //dialogue for package delivered
            metToney = true;
        }
        if (theArts && !wesleyPaintsDelivered)
        {
            dialogueHandler.InitDialogueTree(dialogueTrees[2], "Wesley Stashwell", VOICE_TYPE.Masculine); //dialogue for package delivered
            wesleyPaintsDelivered = true;
        }
     /*   if (packageLocation1.isCorrectPackage && !bMVaseDelivered)
        {
            dialogueHandler.InitDialogueTree(dialogueTrees[3], "Toney Immaculate", VOICE_TYPE.Masculine); //dialogue for package delivered
            bMVaseDelivered = true;
        }*/

    }
}
