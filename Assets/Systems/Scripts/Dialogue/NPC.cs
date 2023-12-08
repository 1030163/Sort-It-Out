using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogueHandler dialogueHandler;
    public DialogueTree[] dialogueTrees;
    public NPCDialogue[] singularDialogue;
    [SerializeField] private string NPCName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            dialogueHandler.InitDialogueTree(dialogueTrees[0]);
        }

        else if (Input.GetKeyDown(KeyCode.O))
        {
            dialogueHandler.InitSingularDialogue(singularDialogue[0], "Mildred Brown");
        }
    }
}
