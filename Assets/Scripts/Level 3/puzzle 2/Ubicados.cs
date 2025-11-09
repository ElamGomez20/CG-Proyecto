using System.Collections.Generic;
using UnityEngine;

public class Ubicados : MonoBehaviour
{
    public List<GameObject> wall;
    public List<GameObject> trigger;

    private List<GameObject> triggersActivados = new List<GameObject>();
    private bool subirMuros = false;
    public float posY = 2f;
    public float velocidad = 1f;

    private Dictionary<GameObject, Vector3> posicionesIniciales = new Dictionary<GameObject, Vector3>();

    void Start()
    {
        foreach (GameObject w in wall)
        {
            posicionesIniciales[w] = w.transform.position;
        }
    }

    void Update()
    {
        if (subirMuros)
        {
            bool todosListos = true;

            foreach (GameObject w in wall)
            {
                Vector3 targetPos = posicionesIniciales[w] + new Vector3(0, posY, 0);
                w.transform.position = Vector3.Lerp(w.transform.position, targetPos, Time.deltaTime * velocidad);

                if (Vector3.Distance(w.transform.position, targetPos) > 0.01f)
                {
                    todosListos = false;
                }
            }

            if (todosListos)
            {
                subirMuros = false;
            }
        }
    }

    public void TriggerActivated(GameObject obt)
    {
        if (trigger.Contains(obt) && !triggersActivados.Contains(obt))
        {
            triggersActivados.Add(obt);
        }

        if (triggersActivados.Count == trigger.Count)
        {
            subirMuros = true;
        }
    }
}
