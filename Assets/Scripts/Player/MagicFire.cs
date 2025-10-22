using System.Threading;
using UnityEngine;

public class MagicFire : MonoBehaviour
{
    public GameObject FireBall;
    public float speedFB = 20f;
    public float rangeFB = 15f;
    public float fireRate = 1f;

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
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
        GameObject closest = null;
        float minDist = rangeFB;

        foreach (GameObject Monster in Monsters)
        {
            float dist = Vector3.Distance(transform.position, Monster.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = Monster;
            }
        }
        return closest;
    }
}
