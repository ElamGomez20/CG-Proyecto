using UnityEngine;

public class TriggerNoti : MonoBehaviour
{
    public Ubicados ubicados;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runas"))
        {
            ubicados.TriggerActivated(this.gameObject);
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
