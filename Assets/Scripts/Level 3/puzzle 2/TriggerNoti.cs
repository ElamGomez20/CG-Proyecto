using UnityEngine;

public class TriggerNoti : MonoBehaviour
{
    public Ubicados ubicados;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runas"))
        {
            ubicados.TriggerActivated(this.gameObject);
        }
    }
}
