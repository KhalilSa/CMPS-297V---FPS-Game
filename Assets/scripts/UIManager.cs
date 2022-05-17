using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject pauseUI;
    AudioManager audioManager;
    GameManager gameManager;

    [SerializeField] GameObject playerInfoUI;
/*    private void Awake()
    {
        AudioManager[] objs = FindObjectsOfType<AudioManager>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }*/
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
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
        playerInfoUI.SetActive(true);
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
        playerInfoUI.SetActive(false);
        Time.timeScale = 0;
        GameManager.gameIsPaused = true;
        audioManager.playOnly("PauseHorrorSound");
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.restartGame();
    }

    public void loadNextScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.restartGame();
        gameManager.loadNextLevel();
    }

}
