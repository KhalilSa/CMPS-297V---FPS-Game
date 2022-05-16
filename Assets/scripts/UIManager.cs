using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject pauseUI;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameHasEnded)
        {
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameManager.gameIsPaused) resume();
                else pause();
            }
        }
    }

    public void resume() {
        Cursor.lockState = CursorLockMode.Locked;
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        GameManager.gameIsPaused = false;
        audioManager.stop("PauseHorrorSound");
    }

    public void loadMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void quitLevel() {
        print("Quit");
        Application.Quit();
    }

    void pause() {
        Cursor.lockState = CursorLockMode.None;
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        GameManager.gameIsPaused = true;
        audioManager.playOnly("PauseHorrorSound");
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.restartGame();
        Time.timeScale = 1;
    }

}
