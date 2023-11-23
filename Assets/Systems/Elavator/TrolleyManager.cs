using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyManager : MonoBehaviour
{
    PackageEventManager packageEventManager;
    [SerializeField] GameObject package1;
    [SerializeField] GameObject package2;
    [SerializeField] GameObject package3;
    [SerializeField] GameObject package4;
    [SerializeField] GameObject package5;
    [SerializeField] GameObject package6;
    void Awake()
    {
        packageEventManager = FindObjectOfType<PackageEventManager>();
    }

    private void Start()
    {
        if (packageEventManager.day1PackageChecklist[0])
        {
            package1.SetActive(false);
        }
        if (packageEventManager.day1PackageChecklist[1])
        {
            package2.SetActive(false);
        }
        if (packageEventManager.day1PackageChecklist[2])
        {
            package3.SetActive(false);
        }
        if (packageEventManager.day1PackageChecklist[3])
        {
            package4.SetActive(false);
        }
        if (packageEventManager.day1PackageChecklist[4])
        {
            package5.SetActive(false);
        }
        if (packageEventManager.day1PackageChecklist[5])
        {
            package6.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
