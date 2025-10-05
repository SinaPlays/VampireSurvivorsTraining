using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIscript : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;

    [SerializeField] TextMeshProUGUI vsyncText;
    [SerializeField] TextMeshProUGUI fullScreenText;

    [SerializeField] TextMeshProUGUI highScoreText;


    private void Start()
    {
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
}
