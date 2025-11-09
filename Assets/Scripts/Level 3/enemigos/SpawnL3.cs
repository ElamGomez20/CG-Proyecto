using UnityEngine;

public class SpawnL3 : MonoBehaviour
{
    public GameObject prefab;
    public Transform player;
    public float radio = 10f;
    public float tiempoEntreSpawn = 2f;
    private float tiempoFaltante;

    void Start()
    {
        tiempoFaltante = tiempoEntreSpawn;
    }

    void Update()
    {
        tiempoFaltante -= Time.deltaTime;

        if (tiempoFaltante <= 0f)
        {
            InstanciarCercaDelJugador();
            tiempoFaltante = tiempoEntreSpawn;
        }
    }

    void InstanciarCercaDelJugador()
    {
        Vector2 posicionAleatoria = Random.insideUnitCircle * radio;
        Vector3 posicionDeSpawn = new Vector3(player.position.x + posicionAleatoria.x, player.position.y, player.position.z + posicionAleatoria.y);
        GameObject nuevo = Instantiate(prefab, posicionDeSpawn, Quaternion.identity);
        EnemyFollow enemyFollow = nuevo.GetComponent<EnemyFollow>();
        if (enemyFollow != null)
        {
            enemyFollow.player = player.gameObject;
        }
    }
}
