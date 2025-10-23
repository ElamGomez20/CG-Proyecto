    using UnityEngine;

public class Colores : MonoBehaviour
{

    private Renderer cubeRenderer;
    private bool red = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material.color = Color.red; 
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (red)
            {
                cubeRenderer.material.color = Color.green;
                red = false; 
            }
            else
            {
                cubeRenderer.material.color = Color.red;
                red = true;
            }
        }
    }
}
