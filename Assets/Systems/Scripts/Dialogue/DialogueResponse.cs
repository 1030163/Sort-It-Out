using UnityEngine;

[CreateAssetMenu(fileName = "New Response")]
public class DialogueResponse : ScriptableObject {

    [Header("This is what will be displayed on the button text")]
    public string response;

    [Space(15)]
    [Header("Only add to one of theses!")]
    [Header("This is what will play when a response button is pressed!")]
    public DialogueTree responseTree;
    public NPCDialogue responseDialogue;

}
