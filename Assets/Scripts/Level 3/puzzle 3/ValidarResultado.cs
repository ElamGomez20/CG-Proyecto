using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValidarResultado : MonoBehaviour
{
    public GameObject pared;
    public float altura = 2f;        
    public float velocidad = 1f;

    private bool subir = false;
    private Vector3 posicionFinal;

    public TMP_InputField inputCodigo;
    public string resultado = "568";

    void Update()
    {
       
        if (!subir && inputCodigo.text == resultado)
        {
            posicionFinal = pared.transform.position + new Vector3(0, altura, 0);
            subir = true;
        }

        
        if (subir)
        {
            pared.transform.position = Vector3.MoveTowards(
                pared.transform.position,
                posicionFinal,
                velocidad * Time.deltaTime
            );

            if (pared.transform.position == posicionFinal)
            {
                subir = false;
            }
        }
    }
}

