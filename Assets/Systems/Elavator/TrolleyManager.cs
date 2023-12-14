using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyManager : MonoBehaviour
{
    PackageEventManager packageEventManager;
    [SerializeField] GameObject[] packagePrefabs;
    GameObject packageDetector;

    void Awake()
    {
        packageEventManager = FindObjectOfType<PackageEventManager>();

        if (packageDetector == null )
        {
            packageDetector = GameObject.Find("PackageDetector");
        }
    }

    private void Start()
    {
        if (packageEventManager != null && packageEventManager.packagesToSpawn != null) 
        {
            for (int i = 0; i < packageEventManager.packagesToSpawn.Length; i++)
            {
                string packageName = packageEventManager.packagesToSpawn[i];
                for (int j = 0; j < packagePrefabs.Length; j++)
                {
                    // Get the name of the prefab
                    string prefabName = packagePrefabs[j].name;

                    // Compare the names
                    if (packageName == prefabName)
                    {
                        // Spawn the object prefab at j, with positions and rotations
                        Instantiate(packagePrefabs[j], packageEventManager.packagesToSpawnPositions[i], packageEventManager.packagesToSpawnRotations[i], packageDetector.transform);
                        break; // Assuming there's only one matching prefab for each object
                    }
                }
            }
        }


        //if (packageToInstantiate != null && packageSpawnPoint != null)
        {

        //    Instantiate(prefabToInstantiate, packageSpawnPoint.position, packageSpawnPoint.rotation);
        }

    }

}
