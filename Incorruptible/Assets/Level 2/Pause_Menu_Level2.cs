using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu_Level2 : MonoBehaviour
{
    public GameObject pauseMenu2;

    private static bool isPaused2 = false;

    private void Awake()
    {
        isPaused2 = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused2)
                ResumeGame();
            else
                PauseGame();
        }
    }
    public void PauseGame()
    {
        pauseMenu2.SetActive(true);
        Time.timeScale = 0f;
        isPaused2 = true;


    }
    public void ResumeGame()
    {
        pauseMenu2.SetActive(false);
        Time.timeScale = 1f;
        isPaused2 = false;

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
