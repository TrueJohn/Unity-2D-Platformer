using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_Level_0 : MonoBehaviour
{
    public GameObject pauseMenu;

    private static bool isPaused=false;
    private void Awake()
    {
        isPaused = false;
        
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale =0f;
        isPaused = true;
    }
    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
