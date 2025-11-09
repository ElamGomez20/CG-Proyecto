using UnityEngine;

public class SpawnOFF : MonoBehaviour
{
    public SpawnL3 spawnScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("GigaPlayer") || other.CompareTag("TinyPlayer"))
            spawnScript.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("GigaPlayer") || other.CompareTag("TinyPlayer"))
            spawnScript.enabled = true;
    }
}
