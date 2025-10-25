using UnityEngine;

public class select : MonoBehaviour
{

    public Camera playerCamera;
    public float rayDistance = 12f;
    public LayerMask wallLayer;
    public LayerMask objLayer;
    public GameObject objetoIzquierdo;
    public GameObject objetoDerecho;
    public float offsetIzquierdo = 0.1f;
    public float offsetDerecho = 0.1f;
    public float rotacionExtraY = 270f;
    public bool pick = false;
    private GameObject ultimoIzquierdo;
    private GameObject ultimoDerecho;
    public AudioSource audioSource;   
    public AudioClip sonidoColocar; 

    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, wallLayer | objLayer))
        {
            if (pick && hit.collider.CompareTag("muro"))
            {
                if (Input.GetMouseButtonDown(0))
                    ColocarObjeto(ref ultimoIzquierdo, objetoIzquierdo, hit, offsetIzquierdo);
                else if (Input.GetMouseButtonDown(1))
                    ColocarObjeto(ref ultimoDerecho, objetoDerecho, hit, offsetDerecho);
            }

            if (hit.collider.CompareTag("obji"))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pick = true;

                    staff interaccion = hit.collider.GetComponent<staff>();
                    if (interaccion != null) interaccion.EjecutarAccion();
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
        }
    }

    void ColocarObjeto(ref GameObject ultimo, GameObject prefab, RaycastHit hit, float offset)
    {
        if (prefab == null) return;

        if (ultimo != null) Destroy(ultimo);
        Vector3 posicionFinal = hit.point + hit.normal * offset;

        Quaternion rotacionFinal = Quaternion.LookRotation(hit.normal);
        rotacionFinal *= Quaternion.Euler(0f, 180f, 0f);
        rotacionFinal *= Quaternion.Euler(0f, rotacionExtraY, 0f);

        ultimo = Instantiate(prefab, posicionFinal, rotacionFinal);
        if (audioSource != null && sonidoColocar != null)
            audioSource.PlayOneShot(sonidoColocar);
    }
}
