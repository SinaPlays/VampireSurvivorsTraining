using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIscript : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;

    [SerializeField] TextMeshProUGUI vsyncText;

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
    public void EnableDesableVsync()
    {
        if (QualitySettings.vSyncCount == 0)
        {
            QualitySettings.vSyncCount = 1;
            vsyncText.text = "VSync: On";
            Debug.Log("VSync Enabled");
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            vsyncText.text = "VSync: Off";
            Debug.Log("VSync Disabled");
        }
    }
}
