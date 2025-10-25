using UnityEngine;

public class staff : MonoBehaviour
{
    public GameObject objetoAparecer;

   
    public bool desactivarEste = true;

    public AudioClip sonidoRecoger;
    private AudioSource audioSource;

    private bool sonidoReproducido = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }
    public void EjecutarAccion()
    { 
        if (sonidoRecoger != null && !sonidoReproducido)
        {
            audioSource.clip = sonidoRecoger;
            audioSource.Play();
            sonidoReproducido = true;
        }
    
        if (objetoAparecer != null)
        {
            objetoAparecer.SetActive(true);
        }
        if (desactivarEste)
        {
            gameObject.SetActive(false);
        }
    }
}
