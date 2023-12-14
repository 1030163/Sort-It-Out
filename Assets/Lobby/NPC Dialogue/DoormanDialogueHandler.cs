using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoormanDialogueHandler : MonoBehaviour
{
    [SerializeField] private DialogueHandler dialogueHandler;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject playerCharacter;

    public DialogueTree[] dialogueTree;

    private bool isTalking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("NPC player: " + gameObject.layer);
        Ray ray = new Ray(player.transform.position, transform.forward);
        float maxDistance = 4f;

        RaycastHit hit;
        int layerMask = Physics.DefaultRaycastLayers;

        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            if (hit.collider.CompareTag("NPC"))
            {
                //Debug.Log("NPC Detected");
                if (Input.GetKeyDown(KeyCode.E) && !dialogueHandler.isTalking)
                {
                    Debug.Log("E key pressed");
                    dialogueHandler.InitDialogueTree(dialogueTree[0], "Doorman", VOICE_TYPE.Masculine);
                    isTalking = true;
                }
            }
            else
            {
                //Debug.Log("Collider does not have the NPC tag.");
            }
        }
        if (dialogueHandler.isTalking)
        {
            playerCharacter.GetComponent<NonVrCharacterControllerNEW>().enabled = false;
        }
        else
        {
            playerCharacter.GetComponent<NonVrCharacterControllerNEW>().enabled = true;
        }
    }
    
}
