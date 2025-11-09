using System.Collections.Generic;
using UnityEngine;

public class CubosNecesarios : MonoBehaviour
{
    public List<GameObject> activateCube;
    public List<GameObject> deactivateCube;

    private Renderer rend;
    public List<GameObject> Wall;

    public AudioSource audioMoverPared;
    private bool sonidoReproducido = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool green = true;
        bool red = true;

        foreach (GameObject cube in activateCube)
        {
            rend = cube.GetComponent<Renderer>();
            if (rend.material.color != Color.green)
            {
                green = false;
                break;
            }
        }

        foreach (GameObject cube in deactivateCube)
        {
            rend = cube.GetComponent<Renderer>();
            if (rend.material.color != Color.red)
            {
                red = false;
                break;
            }
        }

        if (green && red)
        {
            if (!sonidoReproducido && audioMoverPared != null)
            {
                audioMoverPared.Play();
                sonidoReproducido = true;
            }

            foreach (GameObject wall in Wall) 
            {
                Vector3 targetPos = wall.transform.position + new Vector3(0, -5f, 0); 
                wall.transform.position = Vector3.Lerp(wall.transform.position, targetPos, Time.deltaTime);
            }
        }

    }

}
