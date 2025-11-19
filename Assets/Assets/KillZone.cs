using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        MovementPlayer mp = collision.gameObject.GetComponent<MovementPlayer>();
        if (mp != null)
        {
            mp.RespawnAtCheckpoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        MovementPlayer mp = other.GetComponent<MovementPlayer>();
        if (mp != null)
        {
            mp.RespawnAtCheckpoint();
        }
    }
}
