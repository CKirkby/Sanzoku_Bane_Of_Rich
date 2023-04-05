using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject playerUI;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == true)
            {
                ResumeGame();
            }
            else if (isPaused == false)
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        playerUI.SetActive(false);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
