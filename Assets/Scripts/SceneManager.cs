using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private static bool created = false;
    // Start is called before the first frame update
    void Start()
    {
        CheckIfThisExists();
        LoadLevelOne();
    }
    private void CheckIfThisExists()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void LoadLevelOne()
    {
        var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        var sceneName = currentScene.name;
        if(sceneName == "Main")
        {
            Debug.Log("Changing Scenes...");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
        }
        else
        {
            Debug.Log("All good");
        }
    }
}
