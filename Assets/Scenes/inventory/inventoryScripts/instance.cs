using UnityEngine;
using TMPro; 

public class NotasManager : MonoBehaviour
{
    public static NotasManager instancia;

    [Header("Texto del Canvas (TextMeshPro)")]
    public TMP_Text textoTMP; 

    [Header("Contador de notas")]
    public int notasRecogidas = 0;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        ActualizarTexto();
    }

    public void AgregarNota()
    {
        notasRecogidas++;
        ActualizarTexto();
    }

    public void ActualizarTexto()
    {
        if (textoTMP != null)
            textoTMP.text = "Notas: " + notasRecogidas;
    }
}
