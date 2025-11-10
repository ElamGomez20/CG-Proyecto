using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaSiguiente : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
     
        if (other.CompareTag("Player"))
        {
     
            int escenaActual = SceneManager.GetActiveScene().buildIndex;

           
            SceneManager.LoadScene(escenaActual + 1);
        }
    }
}

