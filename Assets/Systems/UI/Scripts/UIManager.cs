using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public static bool uiLoaded = false;

    public static int controlNumber;
    public static bool controlPromptActive = false;

    public static bool objectHeld = false;

    public static int inspectNumber;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        if (!uiLoaded)
        {
            SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);
            uiLoaded = true;
        }

    }

    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
