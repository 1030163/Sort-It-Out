using System.Collections;
using UnityEngine;
using TMPro;

public class PrintDialogue : MonoBehaviour {

    public GameObject confirmButton;
    [SerializeField] private DialogueHandler dialogueHandler;
    
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private AudioClip[] dialogueAudio;
    [SerializeField] private int charactersBetweenAudio;
    [SerializeField] private int textSpeed;
    [SerializeField] private float textDelay;

    private TextMeshProUGUI dialogueText;
    private AudioSource audioSource;
    private const float minPitch = 0.9f;
    private const float maxPitch = 1.1f;

    private void Awake() {
        dialogueText = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }

    public void InitDialogueText(NPCDialogue npcDialogue, string NPCName) {
        char[] charactersInDialogue = npcDialogue.dialogue.ToCharArray();
        NPCNameText.text = NPCName;

        confirmButton.SetActive(false);

        StopAllCoroutines();
        StartCoroutine(PrintDialogueText(charactersInDialogue, npcDialogue));
    }

    private IEnumerator PrintDialogueText(char[] charactersToPrint, NPCDialogue npcDialogue) {
        for (int i = 0; i < charactersToPrint.Length + 1; i++) {
            dialogueText.text = npcDialogue.dialogue.Substring(0, i);

            if (i % charactersBetweenAudio == 0) {
                PlayDialogueAudio(RandomiseAudioClip());
            }

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

        dialogueHandler.EnableResponseButtons(npcDialogue);
    }

    private void PlayDialogueAudio(AudioClip audioClip) {
        audioSource.pitch = RandomiseAudioPitch();
        audioSource.PlayOneShot(audioClip);

    }

    private float RandomiseAudioPitch() {
        return Random.Range(minPitch, maxPitch);
    }

    private AudioClip RandomiseAudioClip() {
        int r = Random.Range(0, dialogueAudio.Length);
        return dialogueAudio[r];
    }
}
