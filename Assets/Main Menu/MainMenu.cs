using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu, levelMenu;
    public void LevelScreen() {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void MenuScreen() {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
