using UnityEngine;

public enum VOICE_TYPE { Masculine, Feminine }

public class NPC : MonoBehaviour {

    [SerializeField] private DialogueHandler dialogueHandler;

    public DialogueTree[] dialogueTrees;
    public NPCDialogue[] singularDialogue;

}
