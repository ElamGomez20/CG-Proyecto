using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    public Material healthMaterial;
    public float monsterDamage = 1;
    public float Health = 1;
    private float damageAmount;
    private float currentRemoveSegments;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRemoveSegments = 0.02f;
        healthMaterial.SetFloat("_RemoveSegments", currentRemoveSegments);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            currentRemoveSegments += (damageAmount + monsterDamage);
            healthMaterial.SetFloat("_RemoveSegments", currentRemoveSegments);

            HealtController();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Heal"))
        {
            currentRemoveSegments += (damageAmount - Health);
            healthMaterial.SetFloat("_RemoveSegments", currentRemoveSegments);
        }
    }

    private void HealtController()
    {
        if (healthMaterial.GetFloat("_RemoveSegments") >= 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
   
}
