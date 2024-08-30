using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu, playerReticle, finishedMenu, deathMenu;
    private bool isPaused = false;
    public KeyCode pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();
        finishedMenu.SetActive(false);
        deathMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(pauseButton) && !finishedMenu.activeSelf && !deathMenu.activeSelf) {
            if(isPaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    private void PauseGame() {
        pauseMenu.SetActive(true);
        playerReticle.SetActive(false);
        finishedMenu.SetActive(false);
        deathMenu.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }

    private void ResumeGame() {
        pauseMenu.SetActive(false);
        playerReticle.SetActive(true);
        finishedMenu.SetActive(false);
        deathMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void FinishLevel() {
        finishedMenu.SetActive(true);
        pauseMenu.SetActive(false);
        playerReticle.SetActive(false);
        deathMenu.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    public void Death() {
        finishedMenu.SetActive(false);
        pauseMenu.SetActive(false);
        playerReticle.SetActive(false);
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void LoadLevel(string sceneName) {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
