using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PackageUI : MonoBehaviour
{

    [TextArea(15, 15)] public string[] inspectStringArray;

    [SerializeField] private TextMeshProUGUI inspectText;
    [SerializeField] private GameObject inspectPanel;

    private bool currentlyInspecting = false;

    // Start is called before the first frame update
    void Start()
    {
        inspectPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.objectHeld && Input.GetKey(KeyCode.Q))
        {
            inspectPanel.SetActive(true);

            int inspectIndex = UIManager.inspectNumber - 1; // Assuming inspectNumber starts from 1

            if (inspectIndex >= 0 && inspectIndex < inspectStringArray.Length)
            {
                inspectText.text = inspectStringArray[inspectIndex];
            }

            //if (currentlyInspecting)
            //{
            //    inspectPanel.SetActive(false);
            //}
        }
        else
        {
            inspectPanel.SetActive(false);
        }
        //if (currentlyInspecting && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E)))
        //{
        //    inspectPanel.SetActive(false);
        //    inspectText.text = "";
        //}
        
    }
}
