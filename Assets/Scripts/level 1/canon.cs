using System.Collections;
using UnityEngine;

public class ActivarObjetoTemporal : MonoBehaviour
{
    [Header("Referencias de objetos")]
    public GameObject objetoADesaparecer;   
    public GameObject objetoAAparecer;     

    [Header("Audio")]
    public AudioClip sonidoColision;        

    private bool activado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activado)
        {
            activado = true;

       
            if (sonidoColision != null)
            {
                AudioSource.PlayClipAtPoint(sonidoColision, transform.position);
            }

            if (objetoADesaparecer != null)
                objetoADesaparecer.SetActive(false);

            if (objetoAAparecer != null)
                StartCoroutine(MostrarTemporalmente());
        }
    }

    private IEnumerator MostrarTemporalmente()
    {
        objetoAAparecer.SetActive(true);
        yield return new WaitForSeconds(2f);
        objetoAAparecer.SetActive(false);
    }
}
