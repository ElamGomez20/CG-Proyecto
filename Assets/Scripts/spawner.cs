using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefab a Instanciar")]
    public GameObject prefab;

    [Header("Puntos de Spawn")]
    public Transform[] zonasDeSpawn;

    [Header("Configuración de Tiempo")]
    public float tiempoEntreSpawns = 2f; // segundos

    [Header("Límites")]
    public int cantidadMaxima = 10;

    private int cantidadActual = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPrefab), 0f, tiempoEntreSpawns);
    }

    void SpawnPrefab()
    {
        if (cantidadActual >= cantidadMaxima) return;

        // Elige una zona aleatoria
        int indice = Random.Range(0, zonasDeSpawn.Length);

        // Instancia el prefab en la posición de esa zona
        Instantiate(prefab, zonasDeSpawn[indice].position, zonasDeSpawn[indice].rotation);

        cantidadActual++;
    }
}
