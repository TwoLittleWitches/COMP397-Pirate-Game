using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : PersistentSingleton<SceneController>
{
    public void ChangeScene()
    {
        Debug.Log("ChangeScene() to Game Start");
        SceneManager.LoadScene("Level1");
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log("ChangeScene() to " + sceneName);
        SceneManager.LoadScene(sceneName);
    }   

    public void ChangeScene(int buildIndex)
    {
        Debug.Log("ChangeScene() to " + buildIndex);
        SceneManager.LoadScene(buildIndex);
    }
}