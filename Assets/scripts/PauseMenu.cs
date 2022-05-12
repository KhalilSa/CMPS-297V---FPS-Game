using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    [SerializeField]
    GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) resume();
            else pause();
        }
    }

    public void resume() {
        Cursor.lockState = CursorLockMode.Locked;
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void loadMenu() {
        
    }

    public void quitLevel() {
        SceneManager.LoadScene(0);
    }

    void pause() {
        Cursor.lockState = CursorLockMode.None;
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

}
