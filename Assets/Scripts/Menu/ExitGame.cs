using System.Collections;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Se activa solo cuando venimos del final
    public static bool autoQuitNextScene = false;

    // Tiempo antes de cerrar automaticamente
    public float autoQuitDelay = 10f;

    private void Start()
    {
        // Si venimos desde la escena final, iniciamos la cuenta regresiva
        if (autoQuitNextScene)
        {
            autoQuitNextScene = false; // Importante: resetear
            StartCoroutine(AutoQuitCoroutine());
        }
    }

    // Llamado por el boton de salir
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QuitGame ejecutado");
    }

    private IEnumerator AutoQuitCoroutine()
    {
        yield return new WaitForSeconds(autoQuitDelay);
        Application.Quit();
        Debug.Log("AutoQuit ejecutado");
    }

    // Metodo que LLAMAS desde la escena final ANTES de ir al menu
    public static void ActivateAutoQuit()
    {
        autoQuitNextScene = true;
    }
}
