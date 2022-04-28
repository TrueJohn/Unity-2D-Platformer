using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Save_Menu_script : MonoBehaviour
{
    public GameObject login_menu;
    public GameObject signup_menu;
    public GameSettings gameSettings;
    public void Awake()
    {  
        login_menu.SetActive(true);
        signup_menu.SetActive(false);
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

    
    public void Main_Menu()
    {
        SceneManager.LoadScene(0);
    }
    private bool ok = true;
    public void signup_login()
    { 
        login_menu.SetActive(!ok);
        signup_menu.SetActive(ok);
        ok = !ok;

    }
    
}
