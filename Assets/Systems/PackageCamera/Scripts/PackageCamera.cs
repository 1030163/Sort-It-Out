using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class PackageCamera : MonoBehaviour
{
    private PackageLocation packageChecker;
    private TextMeshProUGUI textMeshPro;

    [SerializeField] List<string> PackageDeliveryChecklistNote;
    [SerializeField] List <string> PackageName;
    public List<bool> PackageDeliveryCondition;
    
    


    private void Awake()
    {
        packageChecker = transform.GetChild(0).GetComponent<PackageLocation>();
        textMeshPro = transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Check if package is in the frame
            for (int i = 0; i < PackageName.Count; i++)
            {
                if (packageChecker.packageName == PackageName[i])
                {
                    Debug.Log("package found: " + PackageName[i]);
                    if (PackageDeliveryCondition[i] == true)
                    {
                        //LEFT OFF WORK HERE
                        //
                        //
                        //


                        foreach (string note in PackageDeliveryChecklistNote)
                        {
                            //string checklist = + note;
                        }

                        textMeshPro.text = PackageDeliveryChecklistNote[i];
                        PackageDeliveryChecklistNote[i] = "<s>" + PackageDeliveryChecklistNote[i] + "</s>";
                        Debug.Log("it worked");
                    }
                }
            }
        }

        
        
    }
}
