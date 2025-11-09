using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("GigaPlayer") || other.CompareTag("TinyPlayer"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
