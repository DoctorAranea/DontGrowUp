using UnityEngine;
using UnityEngine.SceneManagement;
public class FillScreen : MonoBehaviour
{
    private int newScene;

    public int NewScene
    {
        get => newScene;
        set
        {
            if (value >= 0)
                newScene = value;
            else
                newScene = 0;
        }
    }

    private void Awake()
    {
        GlobalEventManager.OnPlayerDied.AddListener(RestartLevel);
        GlobalEventManager.OnNewSceneRequested.AddListener(SetNewActiveScene);
    }

    private void SetNewActiveScene(int scene)
    {
        NewScene = scene;
        GetComponent<Animator>().SetTrigger("gameOver");
    }

    private void RestartLevel()
    {
        NewScene = SceneManager.GetActiveScene().buildIndex;
        GetComponent<Animator>().SetTrigger("gameOver");
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(newScene);
    }
}
