using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlPrompts : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private Image promptImage;

    [SerializeField] private string[] promptStringArray;
    [SerializeField] private Sprite[] promptImageArray;
    // Start is called before the first frame update
    void Start()
    {
        promptImage.gameObject.SetActive(false);
        promptText.text = "";
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
                    case 3:
                        promptText.text = promptStringArray[2];
                        promptImage.sprite = promptImageArray[2];
                        break;
                    case 4:
                        promptText.text = promptStringArray[3];
                        promptImage.sprite = promptImageArray[3];
                        break;
                    default:
                        promptImage.gameObject.SetActive(false);
                        promptText.text = "";
                        break;

                }
            }

        }
        else
        {
            promptImage.gameObject.SetActive(false);
            promptText.text = "";
        }
    }
}
