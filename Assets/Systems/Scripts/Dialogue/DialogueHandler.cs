using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour {
    [SerializeField] private PrintDialogue dialoguePrinter;
    [SerializeField] private GameObject dialogueBoxSprite;
    [SerializeField] private GameObject[] responseButtons;
    [SerializeField] private Animator dialogueBoxAnimator;

    private DialogueTree currentTree;
    private int treeCurrentIndex;

    private string NPCTalking;

    private void Update()
    {
        if (dialoguePrinter.confirmButton.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            OnConfirmButtonPressed();
        }
    }

    public void InitSingularDialogue(NPCDialogue dialogue, string NPCName) {
        NPCTalking = NPCName;
        currentTree = null;
        dialogueBoxSprite.SetActive(true);
        dialoguePrinter.InitDialogueText(dialogue, NPCTalking);
    }

    public void InitDialogueTree(DialogueTree dialogueTree) {
        currentTree = dialogueTree;
        dialogueBoxSprite.SetActive(true);
        //dialoguePrinter.InitDialogueText(currentTree.dialogueTree[0]);
    }

    // Is called when the E key is pressed at the end of dialogue
    private void OnConfirmButtonPressed() {

        // If the currently running dialogue is apart of a dialogue tree
        if (currentTree) {
            bool atEndOfTree = (treeCurrentIndex == currentTree.dialogueTree.Length - 1);

            if (!atEndOfTree) {
                treeCurrentIndex++;
                //dialoguePrinter.InitDialogueText(currentTree.dialogueTree[treeCurrentIndex]);
                return;
            }

            print("You've reached the end of the dialogue tree!");
            dialogueBoxSprite.SetActive(false);
            return;
        }

        print("You've reached the end of the dialogue!");
        dialogueBoxSprite.SetActive(false);
    }


    // Response Button Functions
    public void EnableResponseButtons(NPCDialogue dialogue)
    {
        int amountToDisplay = dialogue.dialogueResponse.Length;

        dialogueBoxAnimator.SetInteger("IsRaising", -1);

        for (int i = 0; i < amountToDisplay; i++)
        {
            responseButtons[i].SetActive(true);
            InitResponseButton(dialogue, i);
        }
    }

    public void DisableResponseButtons()
    {
        for (int i = 0; i < responseButtons.Length; i++)
        {
            responseButtons[i].SetActive(false);
        }
    }

    private void InitResponseButton(NPCDialogue dialogue, int i)
    {
        responseButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = dialogue.dialogueResponse[i].response;

        if (dialogue.dialogueResponse[i].responseTree)
        {
            responseButtons[i].GetComponent<Button>().onClick.AddListener(delegate {
                RunDialogueTreeOnResponse(dialogue.dialogueResponse[i].responseTree);
            });

            return;
        }

        responseButtons[i].GetComponent<Button>().onClick.AddListener(delegate {
            RunSingularDialogueOnResponse(dialogue.dialogueResponse[i].responseDialogue);
        });
    }

    private void RunDialogueTreeOnResponse(DialogueTree dialogueTree)
    {
        DisableResponseButtons();
        dialogueBoxAnimator.SetInteger("IsRaising", 1);
        InitDialogueTree(dialogueTree);
    }

    private void RunSingularDialogueOnResponse(NPCDialogue singularDialogue)
    {
        DisableResponseButtons();
        dialogueBoxAnimator.SetInteger("IsRaising", 1);
        InitSingularDialogue(singularDialogue, NPCTalking);
    }
}