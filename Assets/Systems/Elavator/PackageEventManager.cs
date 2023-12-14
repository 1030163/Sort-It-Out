using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PackageEventManager : MonoBehaviour
{
    public bool [] day1PackageChecklist;
    public static PackageEventManager eventManager;
    public bool day1AllTrue;
    public string[] packagesToSpawn;
    public Vector3[] packagesToSpawnPositions;
    public Quaternion[] packagesToSpawnRotations;
    [SerializeField] Canvas day1CompleteCanvas;
    bool day1CompleteCanvasOn;
    bool movedToNextScene;


    //handles what happens when a PackageEvent is called
    private void Awake()
    {
        if (eventManager == null)
        {
            eventManager = this;
            DontDestroyOnLoad(gameObject);
        }
        day1AllTrue = false;
    }
    private void Start()
    {
        if (PackageEvents.packageEvents != null)
        {
            PackageEvents.packageEvents.OnF1D1P1 += OnF1D1P1;
            PackageEvents.packageEvents.OnF1D1P2 += OnF1D1P2;
            PackageEvents.packageEvents.OnF2D1P1 += OnF2D1P1;
            PackageEvents.packageEvents.OnF2D1P2 += OnF2D1P2;
            PackageEvents.packageEvents.OnF3D1P1 += OnF3D1P1;
            PackageEvents.packageEvents.OnF3D1P2 += OnF3D1P2;
           // PackageEvents.packageEvents.OnSaveTrolleyPackageState += OnSaveTrolleyPackageState;

        }
        else
        {
            Debug.LogError("PackageEvents.packageEvents is null. Make sure you have an instance of PackageEvents in your scene.");
        }

        day1CompleteCanvasOn = false;
    }

    private void Update()
    {
        CheckDay1Completion();
        if (day1CompleteCanvasOn)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Day1Complete();
            }
        }

    }

    private void CheckDay1Completion()
    {
        day1AllTrue = !day1PackageChecklist.Any(check => check == false);

        if (day1AllTrue && movedToNextScene == false)
        {
            day1CompleteCanvas.gameObject.SetActive(true);
            day1CompleteCanvasOn = true;
            Debug.Log("All packages for Day 1 successfully delivered");
        }
    }
    private void OnF1D1P1()
    {
        //Code of what happens when event triggered go here.
        //checks off the package in checklist
        day1PackageChecklist[0] = true;
      

        Debug.Log("Floor 1 Package 1 delivered");
    }

    private void OnF1D1P2()
    {
        day1PackageChecklist[1] = true;

        Debug.Log("Floor 1 Package 2 delivered");
    }

    private void OnF2D1P1()
    {
        day1PackageChecklist[2] = true;

        Debug.Log("Floor 2 Package 1 delivered");
    }

    private void OnF2D1P2()
    {
        day1PackageChecklist[3] = true;

        Debug.Log("Floor 2 Package 2 delivered");
    }

    private void OnF3D1P1()
    {
        day1PackageChecklist[4] = true;

        Debug.Log("Floor 3 Package 1 delivered");
    }

    private void OnF3D1P2()
    {
        day1PackageChecklist[5] = true;

        Debug.Log("Floor 3 Package 2 delivered");
    }

   /* private void OnSaveTrolleyPackageState()
    {
        
        TrolleyPackageDetector trolleyPackageDetector = FindObjectOfType<TrolleyPackageDetector>();
        List<GameObject> trolleyPackages = trolleyPackageDetector.packagesInTrolley;

        if (trolleyPackages != null)
        {
            packagesToSpawn = new string[trolleyPackages.Count];
            packagesToSpawnPositions = new Vector3[trolleyPackages.Count];
            packagesToSpawnRotations = new Quaternion[trolleyPackages.Count];

            for (int i = 0; i < trolleyPackages.Count; i++)
            {
                packagesToSpawn[i] = trolleyPackages[i].gameObject.name;
                packagesToSpawnPositions[i] = trolleyPackages[i].gameObject.transform.position;
                packagesToSpawnRotations[i] = trolleyPackages[i].gameObject.transform.rotation;
            }
        }

    }*/

    public void Day1Complete()
    {
        SceneManager.LoadScene(0);
        day1CompleteCanvas.gameObject.SetActive(false);
        day1CompleteCanvasOn = false;
        movedToNextScene = true;
    }

}