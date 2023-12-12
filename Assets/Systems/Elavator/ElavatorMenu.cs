using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ElavatorMenu : MonoBehaviour
{
    [SerializeField] Canvas menu;
    [SerializeField] TMP_Text sceneNumberText;

    private void Update()
    {
        UpdateFloorNumber();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // Toggle the menu's active state
            if (menu != null)
            {
                menu.gameObject.SetActive(!menu.gameObject.activeSelf);
            }
        }
    }

    private void UpdateFloorNumber()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int sceneNumber = currentScene.buildIndex;

        // Update the text of the Text component
        if (sceneNumberText != null && sceneNumber == 3)
        {
            sceneNumberText.text = "Current Floor: Lobby";
        }
        if (sceneNumberText != null && sceneNumber == 4)
        {
            sceneNumberText.text = "Current Floor: Floor1";
        }
        if (sceneNumberText != null && sceneNumber == 4)
        {
            sceneNumberText.text = "Current Floor: Floor2";
        }
        if (sceneNumberText != null && sceneNumber == 5)
        {
            sceneNumberText.text = "Current Floor: Floor3";
        }
        if (sceneNumberText != null && sceneNumber == 6)
        {
            sceneNumberText.text = "Current Floor: Floor1";
        }
        if (sceneNumberText != null && sceneNumber == 7)
        {
            sceneNumberText.text = "Current Floor: Floor2";
        }
        if (sceneNumberText != null && sceneNumber == 8)
        {
            sceneNumberText.text = "Current Floor: Floor3";
        }
    }

}
