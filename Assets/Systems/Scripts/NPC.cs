using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private NPCDialogue[] dialogue;
    [SerializeField] private PrintDialogue printDialogue;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            printDialogue.InitDialogueText(dialogue[0]);

        else if (Input.GetKeyDown(KeyCode.O))
            printDialogue.InitDialogueText(dialogue[1]);
    }
}
