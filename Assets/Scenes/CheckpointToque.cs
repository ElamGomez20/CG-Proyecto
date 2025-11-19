using UnityEngine;

public class CheckpointToque : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        MovementPlayer mp = other.GetComponent<MovementPlayer>();
        if (mp != null)
        {
            mp.SetCheckpoint(transform.position);
            // Debug.Log("Checkpoint actualizado a: " + transform.position);
        }
    }
}
