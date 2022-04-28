using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;

public class Options_script : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown textureQualityDropdown;
    public TMPro.TMP_Dropdown antialiasingDropdown;
    public TMPro.TMP_Dropdown fpsDropdown;
    public Slider musicVolumeSlider;
    public Button applyButton;

    public AudioSource musicSource;
    public Resolution[] resolutions;
    public GameSettings gameSettings;
    public GameObject ObjectMusic;


    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        ObjectMusic = GameObject.FindWithTag("music");


    }

    void OnEnable()
    {


        gameSettings = new GameSettings();

        if (fullscreenToggle != null)
            fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        if (resolutionDropdown != null)
            resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        if (textureQualityDropdown != null)
            textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        if (antialiasingDropdown != null)
            antialiasingDropdown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
        if (fpsDropdown != null)
            fpsDropdown.onValueChanged.AddListener(delegate { OnFpsDropdown(); });
        if (musicVolumeSlider != null)
            musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        if (applyButton != null)
            applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });



        resolutions = Screen.resolutions;
        int i = 0;
        if (resolutionDropdown != null)
            foreach (Resolution resolution in resolutions)
            {
                resolutionDropdown.options.Add(new TMPro.TMP_Dropdown.OptionData(resolution.ToString()));
                i++;
            }
        if (File.Exists(Application.persistentDataPath + "/gamesettings.json") == true)
        {
            LoadSettings();
        }




    }


    public void OnFullscreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;


    }
    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropdown.value;

    }
    public void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;

    }
    public void OnAntialiasingChange()
    {
        if (antialiasingDropdown.value == 0)
        {
            QualitySettings.antiAliasing = 0;
            gameSettings.antialiasing = 0;
        }
        else if (antialiasingDropdown.value == 1)
        {
            QualitySettings.antiAliasing = 2;
            gameSettings.antialiasing = 1;
        }
        else if (antialiasingDropdown.value == 2)
        {
            QualitySettings.antiAliasing = 4;
            gameSettings.antialiasing = 2;
        }


    }
    public void OnFpsDropdown()
    {
        QualitySettings.vSyncCount = 0;
        if (fpsDropdown.value == 0)
        {
            Application.targetFrameRate = 30;
            gameSettings.fps = fpsDropdown.value;
        }
        else if (fpsDropdown.value == 1)
        {
            Application.targetFrameRate = 60;
            gameSettings.fps = fpsDropdown.value;
        }
        else if (fpsDropdown.value == 2)
        {
            Application.targetFrameRate = 120;
            gameSettings.fps = fpsDropdown.value;
        }

    }
    public void OnMusicVolumeChange()
    {
        ObjectMusic = GameObject.FindWithTag("music");

        musicSource = ObjectMusic.GetComponent<AudioSource>();


        musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;

        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);

    }
    public void OnApplyButtonClick()
    {
        SaveSettings();
    }
    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);

    }
    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        if (musicVolumeSlider != null)
            musicVolumeSlider.value = gameSettings.musicVolume;
        if (antialiasingDropdown != null)
            antialiasingDropdown.value = gameSettings.antialiasing;
        if (fpsDropdown != null)
            fpsDropdown.value = gameSettings.fps;
        if (textureQualityDropdown != null)
            textureQualityDropdown.value = gameSettings.textureQuality;
        if (resolutionDropdown != null)
            resolutionDropdown.value = gameSettings.resolutionIndex;
        if (fullscreenToggle != null)
            fullscreenToggle.isOn = gameSettings.fullscreen;
        Screen.fullScreen = gameSettings.fullscreen;
        if (resolutionDropdown != null)
            resolutionDropdown.RefreshShownValue();

    }
    public void BacktoMenu()
    {

        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel"));

    }


}
