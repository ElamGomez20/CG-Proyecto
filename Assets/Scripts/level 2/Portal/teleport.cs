using UnityEngine;
using System.Linq;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Teleeport : MonoBehaviour
{
    [Header("Configuración del Portal")]
    [Tooltip("Tag del portal enlazado (el de salida)")]
    public string tagPortalEnlazado;

    [Tooltip("Distancia desde el portal de salida donde aparece el objeto")]
    public float offsetSalida = 1f;

    [Tooltip("Evita reentrada inmediata al portal")]
    public float cooldownReentrada = 0.1f;

    [Header("Dirección de salida")]
    [Tooltip("Si está activado, el objeto saldrá en dirección +X local del portal. Si no, en -X local.")]
    public bool salirEnPositivoX = false;

    private Collider portalCollider;

    void Awake()
    {
        portalCollider = GetComponent<Collider>();
        portalCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform salida = ObtenerCloneMasReciente(tagPortalEnlazado);
        if (salida == null) return;

        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;

       
        float velocidadMagnitud = rb.linearVelocity.magnitude;

      
        Vector3 direccionSalida = salirEnPositivoX ? salida.right : -salida.right;

       
        Vector3 nuevaPos = salida.position + direccionSalida * offsetSalida;

    
        rb.position = nuevaPos;

        
        rb.linearVelocity = direccionSalida * velocidadMagnitud;

    
        rb.angularVelocity = Vector3.zero;

 
        Physics.IgnoreCollision(other, portalCollider, true);
        StartCoroutine(RehabilitarColision(other, cooldownReentrada));
    }

    private IEnumerator RehabilitarColision(Collider other, float t)
    {
        yield return new WaitForSeconds(t);
        if (other != null && portalCollider != null)
            Physics.IgnoreCollision(other, portalCollider, false);
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
