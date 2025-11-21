using UnityEngine;

public class MagicFire : MonoBehaviour
{
    public GameObject FireBall;
    public float speedFB = 20f;
    public float rangeFB = 15f;
    public float fireRate = 1f;

    public AudioSource audioSource;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            GameObject target = FindClosestEnemy();
            if (target != null)
            {
                Shoot(target);
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void Shoot(GameObject target)
    {
        GameObject fireball = Instantiate(FireBall, transform.position, Quaternion.identity);

        Vector3 dir = (target.transform.position - transform.position).normalized;

        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            
            rb.linearVelocity = dir * speedFB;
        }

        fireball.transform.rotation = Quaternion.LookRotation(dir);

        Destroy(fireball, 3f);

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        GameObject closest = null;
        float minDist = rangeFB;

        foreach (GameObject monster in monsters)
        {
            float dist = Vector3.Distance(transform.position, monster.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = monster;
            }
        }

        return closest;
    }
}


