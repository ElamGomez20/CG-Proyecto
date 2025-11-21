using UnityEngine;

public class Damage : MonoBehaviour
{
    public Material healthMaterial;
    public float monsterDamage = 1f;

    // Valores de la barra de vida
    public float initialDamageValue = 0.02f;
    public float maxDamageValue = 3f;

    public MovementPlayer player;

    private float damageAmount;
    private float currentRemoveSegments;

    void Start()
    {
        currentRemoveSegments = initialDamageValue;
        healthMaterial.SetFloat("_RemoveSegments", currentRemoveSegments);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        // Log para probar colisiones
        Debug.Log("OnCollisionEnter con: " + other.name + " | Tag: " + other.tag);

        // Daño progresivo por fantasmas
        if (other.CompareTag("Monster"))
        {
            currentRemoveSegments += (damageAmount + monsterDamage);
            healthMaterial.SetFloat("_RemoveSegments", currentRemoveSegments);

            HealthController();
        }
        // Muerte instantanea por colision fisica con muro o agua
        else if (other.CompareTag("muro") || other.CompareTag("Water"))
        {
            KillPlayerInstant("Colision con " + other.tag);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("OnTriggerEnter con: " + other.name + " | Tag: " + other.tag);

        
        if (other.CompareTag("muro") || other.CompareTag("Water"))
        {
            KillPlayerInstant("Trigger con " + other.tag);
        }
    }

    private void HealthController()
    {
        if (healthMaterial.GetFloat("_RemoveSegments") >= maxDamageValue)
        {
            KillPlayerInstant("Vida agotada");
        }
    }

    private void KillPlayerInstant(string reason)
    {
        Debug.Log("KillPlayerInstant -> " + reason);

        if (player != null)
        {
            player.RespawnAtCheckpoint();
        }

        
        currentRemoveSegments = initialDamageValue;
        healthMaterial.SetFloat("_RemoveSegments", currentRemoveSegments);
    }
}
