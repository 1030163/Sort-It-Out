using UnityEngine;

public class EnableObjectOnPackageDelivery : MonoBehaviour {

    [SerializeField] private NPCDialogueHandler npc;

    [Header("Package Interactions")]
    [SerializeField] private GameObject catCollar;
    [SerializeField] private GameObject catFood;
    [SerializeField] private bool isCatCollarPackage;

    private bool enteredTheApartment;

    private void OnTriggerEnter(Collider other) {
        if (isCatCollarPackage && other.gameObject.name == "CatCollar_Collider") {
            catCollar.SetActive(true);
            npc.InitSingularDialogue(npc.singularDialogue[0]); // The Old Lady will thank you for delivering the Cat Collar
        }

        else if (!isCatCollarPackage && other.gameObject.name == "CatFood_Collider") {
            catFood.SetActive(true);
            npc.InitSingularDialogue(npc.singularDialogue[1]); // The Old Lady will thank you for delivering the Cat Food
        }
    }
}
