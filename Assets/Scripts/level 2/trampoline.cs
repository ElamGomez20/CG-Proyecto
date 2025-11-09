using UnityEngine;

public class Trampolin : MonoBehaviour
{
    [Header("Fuerza del salto")]
    public float fuerzaSalto = 15f; // Ajusta la fuerza del impulso

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que toca es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Cancela cualquier movimiento vertical previo y aplica impulso hacia arriba
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
                rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            }
        }
    }
}
