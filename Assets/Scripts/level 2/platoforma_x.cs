using UnityEngine;

public class PlataformaMovimientoX : MonoBehaviour
{
    [Header("Configuración del movimiento")]
    [Tooltip("Distancia que se moverá en el eje X")]
    public float distanciaX = 2f;

    [Tooltip("Tiempo que tarda en ir o volver")]
    public float tiempoMovimiento = 2f;

    [Tooltip("Tiempo que espera en los extremos antes de moverse de nuevo")]
    public float tiempoEspera = 0.5f;

    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private bool moviendoDerecha = true;
    private float t = 0f;

    void Start()
    {
        posicionInicial = transform.position;
        posicionFinal = new Vector3(transform.position.x + distanciaX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        
        t += Time.deltaTime / tiempoMovimiento;

        if (moviendoDerecha)
            transform.position = Vector3.Lerp(posicionInicial, posicionFinal, t);
        else
            transform.position = Vector3.Lerp(posicionFinal, posicionInicial, t);

        
        if (t >= 1f)
        {
            t = 0f;
            moviendoDerecha = !moviendoDerecha;
            StartCoroutine(EsperarCambio());
        }
    }

    private System.Collections.IEnumerator EsperarCambio()
    {
        enabled = false;
        yield return new WaitForSeconds(tiempoEspera);
        enabled = true;
    }
}
