using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class Score_Menu_script : MonoBehaviour
{
    public GameSettings gameSettings;

    public TextMeshProUGUI textGems0;
    public TextMeshProUGUI textGems1;
    public TextMeshProUGUI textGems2;
    public TextMeshProUGUI textGems3;
    public Saved_Data data;
    public void Awake()
    {
        data = JsonUtility.FromJson<Saved_Data>(File.ReadAllText(Application.persistentDataPath + "/" + PlayerPrefs.GetString("User") + ".json"));

        textGems0.text = data.total_score.ToString();
        textGems1.text = data.level1_max_score.ToString()+"/12";
        textGems2.text = data.level2_max_score.ToString()+"/12";
        textGems3.text = data.level3_max_score.ToString()+"/12";

        

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
    
    
    public void Back_Button()
    {
        SceneManager.LoadScene(4);
    }
}
