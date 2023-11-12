using UnityEngine;

public class NPCDialogueHandler : MonoBehaviour {

    [SerializeField] private DialogueTree[] dialogueTrees;
    [SerializeField] private NPCDialogue[] singularDialogue;
    [SerializeField] private PrintDialogue dialogueBox;
    [SerializeField] private GameObject speechBubble;

    private DialogueTree currentTree;
    private int treeCurrentIndex;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            InitDialogueTree(dialogueTrees[0]);
        }

        else if (Input.GetKeyDown(KeyCode.O)) {
            InitSingularDialogue(singularDialogue[0]);
        }
    }

    public void InitSingularDialogue(NPCDialogue dialogue) {
        currentTree = null;
        speechBubble.SetActive(true);
        dialogueBox.InitDialogueText(dialogue);
    }

    public void InitDialogueTree(DialogueTree dialogueTree) {
        currentTree = dialogueTree;
        speechBubble.SetActive(true);
        dialogueBox.InitDialogueText(currentTree.dialogueTree[0]);
    }

    // Is called when the dialogue box's confirm button is pressed
    public void OnConfirmButtonPressed() {

        // If the currently running dialogue is apart of a dialogue tree
        if (currentTree) {
            bool atEndOfTree = (treeCurrentIndex == currentTree.dialogueTree.Length - 1);

            if (!atEndOfTree) {
                treeCurrentIndex++;
                dialogueBox.InitDialogueText(currentTree.dialogueTree[treeCurrentIndex]);
                return;
            }

            print("You've reached the end of the dialogue tree!");
            speechBubble.SetActive(false);
            return;
        }

        print("You've reached the end of the dialogue !");
        speechBubble.SetActive(false);
    }
}