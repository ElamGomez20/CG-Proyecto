using UnityEngine;
using System.Linq;

public class Teleeport : MonoBehaviour
{
    [Header("Configuración del Portal")]
    public string tagPortalEnlazado; 
    public float offsetSalida = 1f;  
    public bool salirPorOpuesto = false; 
    private void OnTriggerEnter(Collider other)
    {
        Transform targetMasReciente = ObtenerCloneMasReciente(tagPortalEnlazado);
        if (targetMasReciente == null) return;

        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 velocidadAntes = rb.linearVelocity;          
            Vector3 direccionSalida = targetMasReciente.right;

            if (salirPorOpuesto)
                direccionSalida *= -1f;       
            other.transform.position = targetMasReciente.position + direccionSalida * offsetSalida;
            rb.linearVelocity = direccionSalida * velocidadAntes.magnitude;
        }
    }
    private Transform ObtenerCloneMasReciente(string tagDestino)
    {
        GameObject[] clones = GameObject.FindGameObjectsWithTag(tagDestino);
        if (clones.Length == 0) return null;

        return clones
            .OrderByDescending(c => c.transform.GetSiblingIndex())
            .First()
            .transform;
    }
}
