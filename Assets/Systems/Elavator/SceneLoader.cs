using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadNewScene(int i)
    {
        SceneManager.LoadScene(i);
        SaveTrolleyPackageState();
    }

    private void SaveTrolleyPackageState()
    {
        //to do: check if trolley is in the elavator
        PackageEvents.packageEvents.SaveTrolleyPackageState();
    }
}
