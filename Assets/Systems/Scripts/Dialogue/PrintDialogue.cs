using System.Collections;
using UnityEngine;
using TMPro;

public class PrintDialogue : MonoBehaviour {

    [SerializeField] private GameObject confirmButton;
    [SerializeField] private DialogueResponseButtonHandler responseHandler;
    [SerializeField] private AudioClip dialogueAudio;
    [SerializeField] private int charactersBetweenAudio;

    [Header("Text Speed Variables")]
    [SerializeField] private int textSpeed;
    [SerializeField] private float textDelay;

    private TextMeshPro speechBubbleText;
    private AudioSource audioSource;

    [SerializeField] private float minPitch = 0.9f;
    [SerializeField] private float maxPitch = 1.2f;

    private void Awake() {
        speechBubbleText = GetComponent<TextMeshPro>();
        audioSource = GetComponent<AudioSource>();
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

            if (i % charactersBetweenAudio == 0) {
                PlayDialogueAudio(dialogueAudio);
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

        responseHandler.EnableResponseButtons(npcDialogue);
    }

    private void PlayDialogueAudio(AudioClip audioClip) {
        audioSource.pitch = RandomiseAudioPitch();
        audioSource.PlayOneShot(audioClip);

    }

    private float RandomiseAudioPitch() {
        return Random.Range(minPitch, maxPitch);
    }
}
