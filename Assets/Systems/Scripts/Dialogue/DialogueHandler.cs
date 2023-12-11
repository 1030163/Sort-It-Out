using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour {

    [SerializeField] private PrintDialogue dialoguePrinter;
    [SerializeField] private Animator dialogueBoxAnimator;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject[] responseButtons;

    private DialogueTree currentTree;
    private int treeCurrentIndex;

    private string NPCTalking;
    private VOICE_TYPE NPCVoiceType;

    private void Update() {
        //more case statements cos shit don't work
        //max was 'ere
        if (dialoguePrinter == null)
        {
            Debug.Log("Update this component: " + gameObject.name + " it is missing some dialogue handler stuff");
            return;
        }

        if (dialoguePrinter.confirmButton.activeSelf && Input.GetKeyDown(KeyCode.E)) {
            OnConfirmButtonPressed();
        }
    }

    public void InitSingularDialogue(NPCDialogue dialogue, string NPCName, VOICE_TYPE voiceType) {
        NPCTalking = NPCName;
        NPCVoiceType = voiceType;

        currentTree = null;
        dialogueBox.SetActive(true);
        dialoguePrinter.InitDialogueText(dialogue, NPCTalking, voiceType);
    }

    public void InitDialogueTree(DialogueTree dialogueTree, string NPCName, VOICE_TYPE voiceType) {
        NPCTalking = NPCName;
        NPCVoiceType = voiceType;

        currentTree = dialogueTree;
        dialogueBox.SetActive(true);
        dialoguePrinter.InitDialogueText(currentTree.dialogueTree[0], NPCName, voiceType);
    }

    // Is called when the E key is pressed at the end of dialogue
    private void OnConfirmButtonPressed() {

        // If the currently running dialogue is apart of a dialogue tree
        if (currentTree) {
            bool atEndOfTree = (treeCurrentIndex == currentTree.dialogueTree.Length - 1);

            if (!atEndOfTree) {
                treeCurrentIndex++;
                dialoguePrinter.InitDialogueText(currentTree.dialogueTree[treeCurrentIndex], NPCTalking, NPCVoiceType);
                return;
            }

            print("You've reached the end of the dialogue tree!");
            dialogueBox.SetActive(false);
            return;
        }

        print("You've reached the end of the dialogue!");
        dialogueBox.SetActive(false);
    }

    #region RESPONSE_FUNCTIONS

    public void EnableResponseButtons(NPCDialogue dialogue) {
        int amountToDisplay = dialogue.dialogueResponse.Length;

        dialogueBoxAnimator.SetInteger("IsRaising", -1);

        for (int i = 0; i < amountToDisplay; i++) {
            responseButtons[i].SetActive(true);
            InitResponseButton(dialogue, i);
        }

        ToggleCursorState(true);
    }

    public void DisableResponseButtons() {
        for (int i = 0; i < responseButtons.Length; i++) {
            responseButtons[i].SetActive(false);
        }
    }

    private void InitResponseButton(NPCDialogue dialogue, int i) {
        responseButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = dialogue.dialogueResponse[i].response;

        if (dialogue.dialogueResponse[i].responseTree) {
            responseButtons[i].GetComponent<Button>().onClick.AddListener(delegate {
                RunDialogueTreeOnResponse(dialogue.dialogueResponse[i].responseTree);
            });

            return;
        }

        responseButtons[i].GetComponent<Button>().onClick.AddListener(delegate {
            RunSingularDialogueOnResponse(dialogue.dialogueResponse[i].responseDialogue);
        });
    }

    private void RunDialogueTreeOnResponse(DialogueTree dialogueTree) {
        LowerDialogueBox();
        InitDialogueTree(dialogueTree, NPCTalking, NPCVoiceType);
    }

    private void RunSingularDialogueOnResponse(NPCDialogue singularDialogue) {
        LowerDialogueBox();
        InitSingularDialogue(singularDialogue, NPCTalking, NPCVoiceType);
    }

    #endregion

    public void LowerDialogueBox() {
        DisableResponseButtons();
        dialogueBoxAnimator.SetInteger("IsRaising", 1);
        ToggleCursorState(false);
    }

    private void ToggleCursorState(bool willToggleOn) {
        if (willToggleOn) {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}