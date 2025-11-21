using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtonLoader : MonoBehaviour
{
    
    public string sceneName = "Menu";

    
    public float delaySeconds = 25f;

    
    public GameObject panelToWatch;

    
    private bool countdownStarted = false;

    void Update()
    {
        
        if (countdownStarted)
        {
            return;
        }

        
        if (panelToWatch != null && panelToWatch.activeSelf)
        {
            countdownStarted = true;
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

   
    public void LoadSceneByName(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.LogWarning("SceneButtonLoader: scene name is empty");
        }
    }

    
    public void LoadConfiguredScene()
    {
        LoadSceneByName(sceneName);
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delaySeconds);
        LoadConfiguredScene();
    }
}
