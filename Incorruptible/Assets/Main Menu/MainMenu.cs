using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public GameSettings gameSettings;
    public void Awake()
    {
        QualitySettings.vSyncCount = 0;
        if (File.Exists(Application.persistentDataPath + "/gamesettings.json") == true)
        {
            gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
            if(gameSettings.fps==0)
            Application.targetFrameRate = 30;
            if(gameSettings.fps==1)
            Application.targetFrameRate = 60;
            if(gameSettings.fps==2)
            Application.targetFrameRate = 120;
        }
        else
            Application.targetFrameRate = 60;
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastLevel", activeScene);
    }
    
    public void PlayGame()
    {
       
        SceneManager.LoadScene(6);

    }
    public void OptionsGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
