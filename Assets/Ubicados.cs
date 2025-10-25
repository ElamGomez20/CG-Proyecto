using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Ubicados : MonoBehaviour
{
    public List<GameObject> wall;
    public List<GameObject> trigger;

    private List<GameObject> triggersActivados = new List<GameObject>();

    public void TriggerActivated(GameObject obt)
    {
        if (trigger.Contains(obt))
        {
            triggersActivados.Add(obt);
        }

        if (triggersActivados.Count == trigger.Count)
        {
            foreach (GameObject w in wall)
            {
                Vector3 targetPos = w.transform.position + new Vector3(0, 2f, 0);
                w.transform.position = Vector3.Lerp(w.transform.position, targetPos, Time.deltaTime);
            }
        }
    }
}

