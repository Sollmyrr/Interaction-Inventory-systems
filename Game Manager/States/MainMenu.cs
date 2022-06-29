using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private StateManager stateManager;

    public void Awake()
    {
        stateManager = StateManager.Instance;
    }

    public void PlayGame()
    {
        stateManager.gameState = GameState.GAMEPLAY;
        stateManager.IsLoading = false;
        SceneManager.Instance.RunScene(1);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
