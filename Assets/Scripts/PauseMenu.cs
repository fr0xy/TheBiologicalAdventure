using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject helpMenuUI;
    public GameObject BlurUI;
    public GameObject tutorialUI;
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }
    public void Resume() {
        pauseMenuUI.SetActive(false);
        helpMenuUI.SetActive(false);
        BlurUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause() {
        pauseMenuUI.SetActive(true);
        BlurUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        if (tutorialUI != null) {
            tutorialUI.SetActive(false);
        }
    }
    public void LoadHelp() {
        helpMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
    public void BackToPauseFromHelp() {
        pauseMenuUI.SetActive(true);
        helpMenuUI.SetActive(false);
    }
    public void Quit() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
