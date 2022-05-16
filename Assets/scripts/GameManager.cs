using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameHasEnded;
    public static bool gameIsPaused;
    [SerializeField] GameObject gameOverMenu;
    AudioManager audioManager;
    private void Awake()
    {
        gameHasEnded = false;
        audioManager = FindObjectOfType<AudioManager>();
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
}
