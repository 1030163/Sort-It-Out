using UnityEngine;

public class CallDialogueOnTrigger : MonoBehaviour {

    [SerializeField] private DialogueHandler dialogueHandler;
    [SerializeField] private DialogueTree Tree_EnterApartment;

    static bool hasDialoguePlayed = false;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !hasDialoguePlayed) {
            hasDialoguePlayed = true;
            GetComponent<BoxCollider>().enabled = false;
            dialogueHandler.InitDialogueTree(Tree_EnterApartment, "Mildred Brown", VOICE_TYPE.Feminine);
        }
    }
}
