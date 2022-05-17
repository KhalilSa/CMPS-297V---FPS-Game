using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int scoreToWin = 2;

    public static bool gameHasEnded;
    public static bool gameIsPaused;
    public static bool levelWon;

    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject levelWonMenu;
    AudioManager audioManager;
    Player player;
    private void Awake()
    {
        GameManager[] objs = FindObjectsOfType<GameManager>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        gameHasEnded = false;
        audioManager = FindObjectOfType<AudioManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void endGame() 
    {
        if (!gameHasEnded) 
        {
            gameHasEnded = true;
            // Show gameOver UI
            showGameOverUI();
            // play gameOver sound
            audioManager.playOnly("GameOver");
        }
    }

    public static void restartGame() 
    {
        gameHasEnded = true;
        Time.timeScale = 1;
    }

    public void showGameOverUI() 
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
    }

    public void checkScore() {
        if (player.score >= scoreToWin) 
        {
            showLevelWonUI();
        }
    }

    public void showLevelWonUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        levelWonMenu.SetActive(true);
    }

    public void loadNextLevel()
    {
        levelWon = false;
        Time.timeScale = 1;
        levelWonMenu.SetActive(false);
    }
}
