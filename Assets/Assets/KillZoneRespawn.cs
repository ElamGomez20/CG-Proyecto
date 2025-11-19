using UnityEngine;

public class KillZoneRespawn : MonoBehaviour
{
    [Header("Checkpoint de respawn")]
    public Transform checkpoint;   // Asigna aqui la posicion a la que quieres que vuelva

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void RespawnToCheckpoint()
    {
        if (checkpoint == null)
        {
            Debug.LogWarning("KillZoneRespawn: checkpoint no asignado.");
            return;
        }

        // Reset de velocidad para evitar empujones raros
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Teletransportar al jugador al checkpoint
        transform.position = checkpoint.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (other.CompareTag("muro") || other.CompareTag("Water"))
        {
            RespawnToCheckpoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("muro") || other.CompareTag("Water"))
        {
            RespawnToCheckpoint();
        }
    }
}
