using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get { return instance; } }
    private static SceneManager instance = null;

    private Scene scene;
    private int currentScene;
    private void Awake()
    {
        Singleton();
    }

    public void Singleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            DontDestroyOnLoad(SceneManager.instance);
        }
        else
        {
            instance = this;
        }
    }

    public void RunScene(int level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }

    public void LoadNextScene()
    {
        currentScene = scene.buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene + 1);
    }

    public int GetNumberOfThisScene()
    {
        currentScene = scene.buildIndex;
        return currentScene;
    }
}

//IF SCENA 0 USTAW MAINMENU STATE IF SCENA 1 GAMEPLAY
//STATEMANAGER.CS NEW GAME BUTTON?