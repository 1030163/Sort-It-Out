using UnityEngine;
using TMPro;
using System.Collections;

public class PrintDialogue : MonoBehaviour
{
    private TextMeshPro speechBubbleText;
    [SerializeField] private int textSpeed;
    [SerializeField] private float textDelay;

    private void Awake()
    {
        speechBubbleText = GetComponent<TextMeshPro>();
    }

    public void InitDialogueText(NPCDialogue npcDialogue)
    {
        char[] charactersInDialogue = npcDialogue.dialogue.ToCharArray();

        StartCoroutine(PrintDialogueText(charactersInDialogue, npcDialogue.dialogue));
    }

    private IEnumerator PrintDialogueText(char[] charactersToPrint, string dialogue)
    {
        for (int i = 0; i < charactersToPrint.Length + 1; i++)
        {
            speechBubbleText.text = dialogue.Substring(0, i);

            yield return new WaitForSeconds(textDelay / textSpeed);
        }
    }
}
