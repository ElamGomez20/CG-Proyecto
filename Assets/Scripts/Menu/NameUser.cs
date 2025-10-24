using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameUser : MonoBehaviour
{
    public TMP_InputField nombreJugador;
    public string escenaJuego = "";

    public void ConfirmarNombre()
    {
        if (!string.IsNullOrEmpty(nombreJugador.text))
        {
            Scoreboard.Instance.nombreJugadorActual = nombreJugador.text;
            SceneManager.LoadScene(escenaJuego);
        }
    }
}