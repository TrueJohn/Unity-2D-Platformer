using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Respawn_Menu_script : MonoBehaviour
{
    public GameSettings gameSettings;
    public void Awake()
    {
        QualitySettings.vSyncCount = 0;
        if (File.Exists(Application.persistentDataPath + "/gamesettings.json") == true)
        {
            gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
            if (gameSettings.fps == 0)
                Application.targetFrameRate = 30;
            if (gameSettings.fps == 1)
                Application.targetFrameRate = 60;
            if (gameSettings.fps == 2)
                Application.targetFrameRate = 120;
        }
        else
            Application.targetFrameRate = 60;
    }

    public void Restart_Level()
    {

        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel"));

    }
    public void Main_Menu()
    {
        SceneManager.LoadScene(4);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
