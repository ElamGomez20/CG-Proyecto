using System.IO;
using UnityEngine;

[System.Serializable]
public class NombreJugadorData
{
    public string nombreJugador;
    public float elapsedTime;

    public NombreJugadorData(string nombre, float tiempo)
    {
        nombreJugador = nombre;
        elapsedTime = tiempo;
    }
}

public class Scoreboard : MonoBehaviour
{
    public static Scoreboard Instance;
    public string nombreJugadorActual;
    public float tiempoJugador;
    private string filePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        filePath = Application.persistentDataPath + "/nombreJugador.json";
        CargarDatos();
    }

    public void GuardarDatos()
    {
        float tiempoActual = TimeController.instance != null ? TimeController.instance.GetElapsedTime() : 0f;
        NombreJugadorData data = new NombreJugadorData(nombreJugadorActual, tiempoActual);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public void CargarDatos()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            NombreJugadorData data = JsonUtility.FromJson<NombreJugadorData>(json);
            nombreJugadorActual = data.nombreJugador;
            tiempoJugador = data.elapsedTime;

            if (TimeController.instance != null)
                TimeController.instance.SetElapsedTime(tiempoJugador);
        }
        else
        {
            nombreJugadorActual = "";
            tiempoJugador = 0f;
        }
    }
}
