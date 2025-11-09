using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{

    [SerializeField] private string tagDelJugador = "Player";

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag(tagDelJugador))
        {
        
            int escenaActual = SceneManager.GetActiveScene().buildIndex;

            
            SceneManager.LoadScene(escenaActual + 1);
        }
    }
}

