using System.Collections;
using UnityEngine;
using TMPro;

public class PrintDialogue : MonoBehaviour {

    public GameObject confirmButton;
    [SerializeField] private DialogueHandler dialogueHandler;
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private AudioClip[] feminineDialogueAudio;
    [SerializeField] private AudioClip[] masculineDialogueAudio;

    [SerializeField] private int charactersBetweenAudio;
    [SerializeField] private int textSpeed;
    [SerializeField] private float textDelay;

    private TextMeshProUGUI dialogueText;
    private AudioSource audioSource;
    private const float minPitch = 0.9f;
    private const float maxPitch = 1.1f;
    private bool isDialogueActive;

    private void Awake() {
        dialogueText = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }

    public void InitDialogueText(NPCDialogue npcDialogue, string NPCName, VOICE_TYPE voiceType) {
        char[] charactersInDialogue = npcDialogue.dialogue.ToCharArray();
        NPCNameText.text = NPCName;

        confirmButton.SetActive(false);
        dialogueHandler.LowerDialogueBox();

        StopAllCoroutines();
        StartCoroutine(PrintDialogueText(charactersInDialogue, npcDialogue, voiceType));
    }

    private IEnumerator PrintDialogueText(char[] charactersToPrint, NPCDialogue npcDialogue, VOICE_TYPE voiceType) {
        isDialogueActive = true;

        for (int i = 0; i < charactersToPrint.Length + 1; i++) {
            dialogueText.text = npcDialogue.dialogue.Substring(0, i);

            if (i % charactersBetweenAudio == 0) {
                PlayDialogueAudio(RandomiseAudioClip(voiceType));
            }

            yield return new WaitForSeconds(textDelay / textSpeed);
        }

        EndOfDialogue(npcDialogue);
        isDialogueActive = false;
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

    private AudioClip RandomiseAudioClip(VOICE_TYPE voiceType) {
        int r = Random.Range(0, feminineDialogueAudio.Length); // Both Arrays are the same length

        if (voiceType == VOICE_TYPE.Feminine) {
            return feminineDialogueAudio[r];
        }

        return masculineDialogueAudio[r];
    }
}
