using System.Collections;
using UnityEngine;
using TMPro;

public class PrintDialogue : MonoBehaviour {

    [SerializeField] private GameObject confirmButton;
    [SerializeField] private DialogueResponseButtonHandler responseHandler;

    [Header("Text Speed Variables")]
    [SerializeField] private int textSpeed;
    [SerializeField] private float textDelay;

    private TextMeshPro speechBubbleText;

    private void Awake() {
        speechBubbleText = GetComponent<TextMeshPro>();
    }

    public void InitDialogueText(NPCDialogue npcDialogue) {
        char[] charactersInDialogue = npcDialogue.dialogue.ToCharArray();

        confirmButton.SetActive(false);

        StopAllCoroutines();
        StartCoroutine(PrintDialogueText(charactersInDialogue, npcDialogue));
    }

    private IEnumerator PrintDialogueText(char[] charactersToPrint, NPCDialogue npcDialogue) {
        for (int i = 0; i < charactersToPrint.Length + 1; i++) {
            speechBubbleText.text = npcDialogue.dialogue.Substring(0, i);

            yield return new WaitForSeconds(textDelay / textSpeed);
        }

        EndOfDialogue(npcDialogue);
    }

    private void EndOfDialogue(NPCDialogue npcDialogue) {
        bool needsResponse = npcDialogue.dialogueResponse.Length > 0;

        if (!needsResponse) {
            confirmButton.SetActive(true);
            return;
        }

        responseHandler.EnableResponseButtons(npcDialogue);
    }
}
