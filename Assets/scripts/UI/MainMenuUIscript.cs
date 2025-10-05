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
        if (Screen.fullScreen == true)
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
