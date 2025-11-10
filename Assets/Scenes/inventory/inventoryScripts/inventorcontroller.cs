using UnityEngine;

public class NotaConCanvas : MonoBehaviour
{
    [Header("Asigna en el Inspector")]
    public Canvas canvas;
    public AudioClip sonidoDesaparicion;

    private bool jugadorDentro = false;
    private bool temporizadorIniciado = false;
    private AudioSource audioSource;

    private void Start()
    {
        
        if (canvas != null)
            canvas.enabled = false;

       
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;

            
            if (canvas != null)
                canvas.enabled = true;

            
            if (NotasManager.instancia != null)
                NotasManager.instancia.AgregarNota();

       
            GetComponent<Collider>().enabled = false;

            
            if (!temporizadorIniciado)
            {
                temporizadorIniciado = true;
                Invoke(nameof(Desaparecer), 8f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
        }
    }

    private void Desaparecer()
    {
        
        if (canvas != null)
            canvas.enabled = false;

        if (sonidoDesaparicion != null)
            audioSource.PlayOneShot(sonidoDesaparicion);

        Destroy(gameObject, sonidoDesaparicion != null ? sonidoDesaparicion.length : 0f);
    }
}
