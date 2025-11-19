using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MovementPlayer mp = other.GetComponent<MovementPlayer>();
            if (mp != null)
            {
                mp.SetCheckpoint(transform.position);
                // Aqui podrias activar particulas, cambiar color, etc.
                // Debug.Log("Checkpoint set at " + transform.position);
            }
        }
    }
}
