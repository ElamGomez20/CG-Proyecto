using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    private float elapsedTime;
    private bool isRunning = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Cada vez que carga una escena, el tiempo sigue corriendo
        isRunning = true;
    }

    private void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    public void SetElapsedTime(float time)
    {
        elapsedTime = time;
    }

    public void PauseTime()
    {
        isRunning = false;
    }

    public void ResumeTime()
    {
        isRunning = true;
    }

    public void ResetTime()
    {
        elapsedTime = 0f;
    }
}
