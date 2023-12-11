using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class ControlPrompts : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private Image promptImage;

    [SerializeField] private Image rotateImage;
    [SerializeField] private TextMeshProUGUI rotateText;

    [SerializeField] private string[] promptStringArray;
    [SerializeField] private Sprite[] promptImageArray;
    // Start is called before the first frame update
    void Start()
    {
        promptImage.gameObject.SetActive(false);
        promptText.text = "";

        rotateImage.gameObject.SetActive(false);
        rotateText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.controlPromptActive)
        {
            promptImage.gameObject.SetActive (true);

            if (UIManager.controlNumber == 0)
            {
                promptImage.gameObject.SetActive(false);
                promptText.text = "";
            }
            else
            {
                switch (UIManager.controlNumber)
                {
                    case 1:
                        promptText.text = promptStringArray[0];
                        promptImage.sprite = promptImageArray[0];
                        break;
                    case 2:
                        promptText.text = promptStringArray[1];
                        promptImage.sprite = promptImageArray[1];
                        break;
                    default:
                        promptImage.gameObject.SetActive(false);
                        promptText.text = "";
                        break;
                }
            }

        }
        else if (UIManager.objectHeld)
        {
            promptText.text = promptStringArray[2];
            promptImage.sprite = promptImageArray[2];
            rotateImage.gameObject.SetActive(true);
            rotateText.gameObject.SetActive(true);
        }
        else
        {
            promptImage.gameObject.SetActive(false);
            promptText.text = "";
        }
        
    }
}
