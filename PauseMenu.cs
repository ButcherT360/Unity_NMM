using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                Cursor.visible = false;
            }
            else
            {
                Pause();
                Cursor.visible = true;
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        look.lookSpeed = 5f;
        look.RotSpeed = 500.0f;
        Cursor.visible = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        look.lookSpeed = 0f;
        look.RotSpeed = 0f;
        Cursor.visible = true;

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        look.lookSpeed = 5f;
        look.RotSpeed = 500.0f;
        SceneManager.LoadScene("Menu");
        Cursor.visible = true;
    }

    public void LoadlastLevel()
    {
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }


    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}