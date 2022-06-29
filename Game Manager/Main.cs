using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance { get { return instance; } }
    private static Main instance = null;

    void Awake()
    {
        Singleton();
    }

    public void Singleton()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning(this.name + " has been deleted");
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Runs before a scene gets loaded
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadMain()
    {
        UnityEngine.GameObject main = UnityEngine.GameObject.Instantiate(Resources.Load("Main")) as UnityEngine.GameObject;
        UnityEngine.GameObject.DontDestroyOnLoad(main);
    }
}