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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
