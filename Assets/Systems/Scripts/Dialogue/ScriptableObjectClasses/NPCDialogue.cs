using UnityEngine;

[CreateAssetMenu(fileName = "New NPC Dialogue")]
public class NPCDialogue : ScriptableObject {

    [TextArea(7, 7)] public string dialogue;

    [Tooltip("Each response will be assigned to its respective button in order (ex. first response will be give to the first button). Make sure there are no more than 3 reponses")]
    public DialogueResponse[] dialogueResponse;
}
