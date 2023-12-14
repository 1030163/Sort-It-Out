using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    private bool gameIsPaused;
    void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            gameIsPaused = true;
            UIManager.gamePaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused)
        {
            pausePanel.SetActive(false);
            settingsPanel.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
            UIManager.gamePaused = false;
            
        }
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SceneManager.UnloadSceneAsync("UIScene");
        UIManager.uiLoaded = false;
    }
}
