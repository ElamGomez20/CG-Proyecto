using UnityEngine;
using UnityEngine.UI;

public class MostrarCanvas : MonoBehaviour
{
    [Header("Asigna en el Inspector")]
    public Canvas canvas;         
    public Button botonCerrar;      

    private void Start()
    {
        
        if (canvas != null)
            canvas.enabled = false;

        if (botonCerrar != null)
            botonCerrar.onClick.AddListener(CerrarCanvas);
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Player"))
        {
            if (canvas != null)
                canvas.enabled = true;
        }
    }

    public void CerrarCanvas()
    {
        if (canvas != null)
            canvas.enabled = false;
    }
}
