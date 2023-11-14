using UnityEngine;
using UnityEngine.UI;

public class DialogueResponseButtonHandler : MonoBehaviour {

    [SerializeField] private NPCDialogueHandler npcDialogueHandler;
    [SerializeField] private GameObject[] responseButtons;

    public void EnableResponseButtons(NPCDialogue dialogue) {
        int amountToDisplay = dialogue.dialogueResponse.Length;

        for (int i = 0; i < amountToDisplay; i++) {
            responseButtons[i].SetActive(true);
            InitResponseButton(dialogue, i);
        }
    }

    public void DisableResponseButtons() {
        for (int i = 0; i < responseButtons.Length; i++) {
            responseButtons[i].SetActive(false);
        }
    }

    private void InitResponseButton(NPCDialogue dialogue, int i) {
        responseButtons[i].GetComponentInChildren<Text>().text = dialogue.dialogueResponse[i].response;

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
        DisableResponseButtons();
        npcDialogueHandler.InitDialogueTree(dialogueTree);
    }

    private void RunSingularDialogueOnResponse(NPCDialogue dialogueToRun) {
        DisableResponseButtons();
        npcDialogueHandler.InitSingularDialogue(dialogueToRun);
    }
}
