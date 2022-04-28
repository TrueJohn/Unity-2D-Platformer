using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
public class Level_Finish_script : MonoBehaviour
{
    public GameSettings gameSettings;
    public TextMeshProUGUI textGems;
    public Stored_data data;
    public Saved_Data data2;
    private int gemsnumber;
    public GameObject next_level;
    public void Awake()
    {
        data = JsonUtility.FromJson<Stored_data>(File.ReadAllText(Application.persistentDataPath + "/stored_data.json"));
        gemsnumber = data.gems;
        textGems.text = gemsnumber.ToString();

        if (PlayerPrefs.GetInt("LastLevel") == 2 || PlayerPrefs.GetInt("LastLevel") == 7)
            next_level.SetActive(true);

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
    void save()
    {
        
        data = JsonUtility.FromJson<Stored_data>(File.ReadAllText(Application.persistentDataPath + "/stored_data.json"));
        gemsnumber = data.gems;
        data2 = JsonUtility.FromJson<Saved_Data>(File.ReadAllText(Application.persistentDataPath + "/" + PlayerPrefs.GetString("User") + ".json"));
        if (PlayerPrefs.GetInt("LastLevel") == 2)
        {
            if (gemsnumber > data2.level1_max_score)
                data2.level1_max_score = gemsnumber;
        }
        else if (PlayerPrefs.GetInt("LastLevel") == 7)
        {
            if (gemsnumber>data2.level2_max_score)
                data2.level2_max_score = gemsnumber;
        }
        else if (PlayerPrefs.GetInt("LastLevel") == 8)
        {
            if (gemsnumber > data2.level3_max_score)
                data2.level3_max_score = gemsnumber;
        }
        data2.total_score += gemsnumber;
        string jsonData = JsonUtility.ToJson(data2, true);
        File.WriteAllText(Application.persistentDataPath + "/" + PlayerPrefs.GetString("User") + ".json", jsonData);
        
    }
    public void Next_Level_Button()
    {

        save();

        if (PlayerPrefs.GetInt("LastLevel") == 2)
        {
            SceneManager.LoadScene(7);
        }
        else if (PlayerPrefs.GetInt("LastLevel") == 7)
        {
            SceneManager.LoadScene(8);
        }
    }
    public void Restart_Level()
    {

        save();
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel"));

    }
    public void Main_Menu()
    {

        save();
        SceneManager.LoadScene(4);
    }
    


}
