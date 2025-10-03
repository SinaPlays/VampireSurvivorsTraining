using NUnit.Framework.Constraints;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    public static StateMachine instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }
    public GameState currentState;
    void Start()
    {
        currentState = GameState.MainMenu;
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.MainMenu:
               if (Input.GetKeyDown(KeyCode.P))
                {
                    ChangeState(GameState.Playing);
                }
                break;
            case GameState.Playing:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ChangeState(GameState.Paused);
                    Time.timeScale = 0;
                }
                break;
            case GameState.Paused:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ChangeState(GameState.Playing);
                    Time.timeScale = 1;
                }
                break;
            case GameState.GameOver:
                
                break;
        }
    }
    public void ChangeState(GameState aState)
    { 
        switch (aState)
        {
            case GameState.MainMenu:
                break;
            case GameState.Playing:
                break;
            case GameState.Paused:
                break;
            case GameState.GameOver:
                break;
        }

        currentState = aState;
    }
}
