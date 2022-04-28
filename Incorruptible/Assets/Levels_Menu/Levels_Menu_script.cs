using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class Levels_Menu_script : MonoBehaviour
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
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastLevel", activeScene);
    }

    public void Level_0()
    {

        SceneManager.LoadScene(2);

    }
    public void Level_1()
    {
        SceneManager.LoadScene(7);
    }
    public void Level_2()
    {
        SceneManager.LoadScene(8);
    }
    public void Main_Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Options()
    {
        SceneManager.LoadScene(1);
    }
    public void Score()
    {
        SceneManager.LoadScene(9);
    }




}
