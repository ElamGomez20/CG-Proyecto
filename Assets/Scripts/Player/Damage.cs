using UnityEngine;

public class Damage : MonoBehaviour
{
    public Material healthMaterial;
    public float monsterDamage = 1f;

    // Values for the health bar
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
        if (collision.gameObject.CompareTag("Monster"))
        {
            currentRemoveSegments += (damageAmount + monsterDamage);
            healthMaterial.SetFloat("_RemoveSegments", currentRemoveSegments);

            HealthController();
        }
    }

    private void HealthController()
    {
        if (healthMaterial.GetFloat("_RemoveSegments") >= maxDamageValue)
        {
            // Player "dies"
            if (player != null)
            {
                player.RespawnAtCheckpoint();
            }

            // Reset health bar
            currentRemoveSegments = initialDamageValue;
            healthMaterial.SetFloat("_RemoveSegments", currentRemoveSegments);
        }
    }
}
