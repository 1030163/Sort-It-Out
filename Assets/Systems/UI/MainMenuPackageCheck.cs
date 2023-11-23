using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPackageCheck : MonoBehaviour
{
    [Header("Is this the Quit Door?")]
    public bool isQuit;

    [Header("Scene to load (if there is one)")]
    public string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Package"))
        {
           if (isQuit)
            {
                StartCoroutine(WaitForQuit());
            }
           
           if (sceneToLoad == "Lobby")
            {
                StartCoroutine(WaitForLobby());
            }

           if (sceneToLoad == "Settings")
            {
                Debug.Log("Settings loaded...if they existed.....hmmm");
            }
        }
    }

    private IEnumerator WaitForQuit()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Application Quit");
        Application.Quit();
    }
    
    private IEnumerator WaitForLobby()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Lobby Greybox");
        Application.Quit();
    }
}
