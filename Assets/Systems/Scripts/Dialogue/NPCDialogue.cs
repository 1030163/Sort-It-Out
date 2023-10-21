using UnityEngine;

[CreateAssetMenu(fileName = "New NPC Dialogue")]
public class NPCDialogue : ScriptableObject
{
    [TextArea] public string dialogue;
}
