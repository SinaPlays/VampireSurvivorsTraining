using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class MainMenuUIscript : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;

    [SerializeField] TextMeshProUGUI vsyncText;
    [SerializeField] TextMeshProUGUI fullScreenText;

    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] private AudioClip mainMenuMusic;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(mainMenuMusic);
            DontDestroyOnLoad(AudioManager.instance);
        }
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();

        if (Screen.fullScreen == true)
        {
            fullScreenText.text = "Fullscreen";
        }
        else
        {
            fullScreenText.text = "Windowed";
        }

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncText.text = "VSync: Off";
        }
        else
        {
            vsyncText.text = "VSync: On";
        }
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        volumeSlider.value = savedVolume;
    }


    public void LoadGameScene()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void VSyncOnOrOff()
    {
        if (QualitySettings.vSyncCount == 0)
        {
            QualitySettings.vSyncCount = 1;
            vsyncText.text = "VSync: On";
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            vsyncText.text = "VSync: Off";
        }
    }
    public void FullscreenOrWindowed()
    {
        if (Screen.fullScreen == true)
        {
            Screen.fullScreen = false;
            fullScreenText.text = "Windowed";
        }
        else
        {
            Screen.fullScreen = true;
            fullScreenText.text = "Fullscreen";
        }
    }
    public void OnChangeAudio(Single volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
}
