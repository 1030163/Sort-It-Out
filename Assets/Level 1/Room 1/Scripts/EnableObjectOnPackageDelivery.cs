using UnityEngine;

public class EnableObjectOnPackageDelivery : MonoBehaviour {

    [SerializeField] private NPC npc;
    [SerializeField] private DialogueHandler dialogueHandler;

    [Header("Package Interactions")]
    [SerializeField] private GameObject catCollar;
    [SerializeField] private GameObject catFood;
    [SerializeField] private bool isCatCollarPackage;

    private void OnTriggerEnter(Collider other) {
        if (isCatCollarPackage && other.gameObject.name == "CatCollar_Collider") {
            catCollar.SetActive(true);
            dialogueHandler.InitSingularDialogue(npc.singularDialogue[0], "Mildred Brown", VOICE_TYPE.Feminine); // The Old Lady will thank you for delivering the Cat Collar
        }

        else if (!isCatCollarPackage && other.gameObject.name == "CatFood_Collider") {
            catFood.SetActive(true);
            dialogueHandler.InitSingularDialogue(npc.singularDialogue[1], "Mildred Brown", VOICE_TYPE.Feminine); // The Old Lady will thank you for delivering the Cat Food
        }
    }
}
