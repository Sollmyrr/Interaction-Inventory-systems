using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { NULLSTATE, INITIALIZE, GAMEPLAY, DIE, INTRO, MAIN_MENU, LOADSCREEN, PAUSE_MENU, CREDITS }

public class StateManager : MonoBehaviour
{
    public event Action<GameState> StateChangeEventHandler;
    public static StateManager Instance { get { return instance; } }
    public GameState gameState { get; set; }
    public bool IsLoading { get; set; }

    private static StateManager instance = null;
    private int sceneIndex;

    private void Awake()
    {
        Singleton();
    }

    public void Singleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            DontDestroyOnLoad(StateManager.instance);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        gameState = GameState.GAMEPLAY;
        IsLoading = false;
        sceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && sceneIndex != 0)
        {
            if (gameState == GameState.PAUSE_MENU)
            {
                gameState = GameState.GAMEPLAY;
                GameStatePublisher(GameState.GAMEPLAY);
            }
            else if (gameState == GameState.GAMEPLAY)
            {
                gameState = GameState.PAUSE_MENU;
                GameStatePublisher(GameState.PAUSE_MENU);
            }
        }

        if (gameState == GameState.MAIN_MENU && !IsLoading)
        {
            SceneManager.Instance.RunScene(0);
            IsLoading = true;
        }
    }

    //Publisher
    public void GameStatePublisher(GameState state)
    {
        Debug.Log("Wywolanie SetGameState (" + state + ")");
        StateChangeEventHandler?.Invoke(state);
    }

    private void DisplayCurrentGameState()
    {
        Debug.Log("Current game state: " + gameState);
    }

    public void OnApplicationQuit()
    {
        StateManager.instance = null;
    }
}

