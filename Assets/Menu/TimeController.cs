using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;
    public TextMeshProUGUI timeText;
    private float elapsedTime;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        if (timeText != null)
            timeText.text = $"{minutes:00}:{seconds:00}";
    }

    
    public void SetElapsedTime(float value)
    {
        elapsedTime = value;
    }
}
