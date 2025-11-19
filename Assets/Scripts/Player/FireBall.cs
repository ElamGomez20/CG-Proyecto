using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float lifetime = 3f;
    public float speed = 20f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            // Contar enemigo derrotado
            if (Scoreboard.Instance != null)
            {
                Scoreboard.Instance.AddEnemyDefeated();
            }

            // Destruir enemigo y la bola de fuego
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
