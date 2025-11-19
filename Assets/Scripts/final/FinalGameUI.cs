using UnityEngine;
using TMPro;

public class FinalGameUI : MonoBehaviour
{
    public GameObject panelFinal;
    public TMP_Text txtTitulo;
    public TMP_Text txtNombre;
    public TMP_Text txtTiempo;
    public TMP_Text txtEnemigos;

    private bool alreadyShown = false;

    void Start()
    {
        if (panelFinal != null)
        {
            panelFinal.SetActive(false);
        }
    }

    public void ShowFinalPanel()
    {
        if (alreadyShown)
        {
            return;
        }

        alreadyShown = true;

        if (panelFinal == null)
        {
            return;
        }

        panelFinal.SetActive(true);

        // Titulo
        if (txtTitulo != null)
        {
            txtTitulo.text = "Juego completado";
        }

        // Nombre del jugador
        string nombre = "Jugador";

        if (Scoreboard.Instance != null && !string.IsNullOrEmpty(Scoreboard.Instance.nombreJugadorActual))
        {
            nombre = Scoreboard.Instance.nombreJugadorActual;
        }

        if (txtNombre != null)
        {
            txtNombre.text = "Jugador: " + nombre;
        }

        // Tiempo total
        float tiempo = 0f;

        if (TimeController.instance != null)
        {
            tiempo = TimeController.instance.GetElapsedTime();
            TimeController.instance.PauseTime();
        }

        if (txtTiempo != null)
        {
            int minutes = Mathf.FloorToInt(tiempo / 60f);
            int seconds = Mathf.FloorToInt(tiempo % 60f);

            txtTiempo.text = "Tiempo: " +
                minutes.ToString("00") + ":" +
                seconds.ToString("00");
        }

        // Enemigos derrotados
        int enemigos = 0;

        if (Scoreboard.Instance != null)
        {
            enemigos = Scoreboard.Instance.enemigosDerrotados;
            Scoreboard.Instance.GuardarDatos();
        }

        if (txtEnemigos != null)
        {
            txtEnemigos.text = "Enemigos derrotados: " + enemigos;
        }
    }
}
