using UnityEngine;

public class PauseMenuUIscript : MonoBehaviour
{
   

    public void ResumeGame()
    {
        GameManager.instance.ChangeState(GameManager.GameState.Playing);
    }
    public void QuitToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void PressR()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
