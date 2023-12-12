using UnityEngine;

public class CallDialogueOnTrigger : MonoBehaviour {

    [SerializeField] private DialogueHandler dialogueHandler;
    [SerializeField] private DialogueTree Tree_EnterApartment;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            GetComponent<BoxCollider>().enabled = false;
            dialogueHandler.InitDialogueTree(Tree_EnterApartment, "Mildred Brown", VOICE_TYPE.Feminine);
        }
    }
}
