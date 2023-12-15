using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FailsafeReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.I))
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }

        if (Input.GetKey(KeyCode.P))
        {
            if (Input.GetKey(KeyCode.Alpha0))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0, UnityEngine.SceneManagement.LoadSceneMode.Single);
            }
            if (Input.GetKey(KeyCode.Alpha1))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Single);
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(2, UnityEngine.SceneManagement.LoadSceneMode.Single);
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(3, UnityEngine.SceneManagement.LoadSceneMode.Single);
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(4, UnityEngine.SceneManagement.LoadSceneMode.Single);
            }
            if (Input.GetKey(KeyCode.Alpha5))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(5, UnityEngine.SceneManagement.LoadSceneMode.Single);
            }
            if (Input.GetKey(KeyCode.Alpha6))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(6, UnityEngine.SceneManagement.LoadSceneMode.Single);
            }
        }
    }
}
