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
    [SerializeField] TextMeshPro interactionText;
    [SerializeField] SceneLoader sceneLoader;
    bool isMenuOn;

    private void Start()
    {
        UpdateFloorNumber();
        isMenuOn = false;
    }
    private void Update()
    {
        if (isMenuOn)
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                sceneLoader.LoadNewScene(3);
            }
            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                sceneLoader.LoadNewScene(4);
            }
            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                sceneLoader.LoadNewScene(5);
            }
            if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                sceneLoader.LoadNewScene(6);
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && Input.GetKeyUp(KeyCode.E))
        {
            // Toggle the menu's active state
            if (menu != null)
            {
                menu.gameObject.SetActive(!menu.gameObject.activeSelf);
                isMenuOn = !isMenuOn;
            }
        }

        interactionText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            menu.gameObject.SetActive(false);
            interactionText.gameObject.SetActive(false);
        }    
        isMenuOn= false;
    }

    private void UpdateFloorNumber()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int sceneNumber = currentScene.buildIndex;
        string sceneName = currentScene.name;
        // Update the text of the Text component
        if (sceneNumberText != null && sceneNumber == 3)
        {
            sceneNumberText.text = "Current Floor: Lobby";
        }
        if (sceneNumberText != null && sceneNumber == 4)
        {
            sceneNumberText.text = "Current Floor: Floor1";
        }
        if (sceneNumberText != null && sceneNumber == 5)
        {
            sceneNumberText.text = "Current Floor: Floor2";
        }
        if (sceneNumberText != null && sceneNumber == 6)
        {
            sceneNumberText.text = "Current Floor: Floor3";
        }
        if (sceneNumberText != null && sceneNumber == 7)
        {
            sceneNumberText.text = "Current Floor: Floor1";
        }
        if (sceneNumberText != null && sceneNumber == 9)
        {
            sceneNumberText.text = "Current Floor: Floor2";
        }
        if (sceneNumberText != null && sceneNumber == 10)
        {
            sceneNumberText.text = "Current Floor: Floor3";
        }
    }

}
