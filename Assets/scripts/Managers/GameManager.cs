using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public static List<EnemyToPlayer> activeEnemies = new List<EnemyToPlayer>();
    public static List<EnemyToPlayer2> activeEnemies2 = new List<EnemyToPlayer2>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("Multiple instances of StateMachine detected. Destroying duplicate.");
            return;
        }
        instance = this;
        Debug.Log("GameManager instance set.");
    }

    CameraFollow cameraFollow;
    PlayerMovement playerMovement;
    GarlicWeapon garlicWeapon;
    WhipWeapon whipWeapon;

    [SerializeField] GameObject UpgradeUI;

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver,
        UpgradeMenu
    }
    public GameState currentState;
    void Start()
    {
        currentState = GameState.MainMenu;
        cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        garlicWeapon = GameObject.FindFirstObjectByType<GarlicWeapon>();
        whipWeapon = GameObject.FindFirstObjectByType<WhipWeapon>();
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

                if (cameraFollow != null) {cameraFollow.UpdateCamera();}
                if (playerMovement != null) {playerMovement.UpdatePlayer(); }
                if (garlicWeapon != null) {garlicWeapon.UpdateGarlic(); }
                if (whipWeapon != null) {whipWeapon.UpdateWhip(); }

                for (int i = 0; i < activeEnemies.Count; i++)
                {
                    activeEnemies[i].UpdateEnemy();
                }
                for (int i = 0; i < activeEnemies2.Count; i++)
                {
                    activeEnemies2[i].UpdateEnemy();
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ChangeState(GameState.Paused);
                }
                break;
            case GameState.Paused:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ChangeState(GameState.Playing);
                }
                break;
            case GameState.GameOver:
                Debug.Log("Game Over! Press R to Restart.");
                if (Input.GetKeyDown(KeyCode.R))
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                }

                break;
            case GameState.UpgradeMenu:

                break;
        }
    }
    public void ChangeState(GameState aState)
    {
        UpgradeUI.SetActive(aState == GameState.UpgradeMenu);
        currentState = aState;
    }
}
