using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu_Level_1 : MonoBehaviour
{
    public GameObject pauseMenu1;

    private static bool isPaused1=false;

    private void Awake()
    {
        isPaused1 = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused1)
                ResumeGame();
            else
                PauseGame();
        }
    }
    public void PauseGame()
    {
        pauseMenu1.SetActive(true);
        Time.timeScale = 0f;
        isPaused1 = true;
        
        
    }
    public void ResumeGame()
    {
        pauseMenu1.SetActive(false);
        Time.timeScale = 1f;
        isPaused1 = false;
        
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
