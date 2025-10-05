using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIscript : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;

    [SerializeField] TextMeshProUGUI vsyncText;
    [SerializeField] TextMeshProUGUI fullScreenText;

    private void Start()
    {
        if (Screen.fullScreen)
        {
            fullScreenText.text = "Fullscreen";
        }
        else
        {
            fullScreenText.text = "Windowed";
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
    public void FullscreenOrWindowed()
    {
        Screen.fullScreen = !Screen.fullScreen;

        if (Screen.fullScreen)
        {
            fullScreenText.text = "Fullscreen";
            Debug.Log("Switched to Fullscreen");
        }
        else
        {
            fullScreenText.text = "Windowed";
            Debug.Log("Switched to Windowed");
        }
    }


}
