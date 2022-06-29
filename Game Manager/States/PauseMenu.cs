using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private StateManager stateManager;

    public void Awake()
    {
        stateManager = StateManager.Instance;
        stateManager.StateChangeEventHandler += HandleOnPauseGame;
    }
    
    public void HandleOnPauseGame(GameState state)
    {
        if (state == GameState.PAUSE_MENU)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }

    public void ResumeMouseOnClick()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        stateManager.gameState = GameState.GAMEPLAY;
    }

    public void LoadMainMenuMouseOnClick()
    {
        stateManager.StateChangeEventHandler -= HandleOnPauseGame;
        pauseMenuUI.SetActive(false);
        stateManager.gameState = GameState.MAIN_MENU;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
