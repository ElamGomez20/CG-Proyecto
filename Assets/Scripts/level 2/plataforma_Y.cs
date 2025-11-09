using UnityEngine;

public class PlataformaMovimiento : MonoBehaviour
{
    [Header("Configuración del movimiento")]
    [Tooltip("Distancia que se moverá en el eje Y")]
    public float distanciaY = 2f;

    [Tooltip("Tiempo que tarda en subir o bajar")]
    public float tiempoMovimiento = 2f;

    [Tooltip("Esperar en la posición superior e inferior")]
    public float tiempoEspera = 0.5f;

    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private bool subiendo = true;
    private float t = 0f;

    void Start()
    {
        posicionInicial = transform.position;
        posicionFinal = new Vector3(transform.position.x, transform.position.y + distanciaY, transform.position.z);
    }

    void Update()
    {
        t += Time.deltaTime / tiempoMovimiento;

        if (subiendo)
            transform.position = Vector3.Lerp(posicionInicial, posicionFinal, t);
        else
            transform.position = Vector3.Lerp(posicionFinal, posicionInicial, t);

      
        if (t >= 1f)
        {
            t = 0f;
            subiendo = !subiendo;
           
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
