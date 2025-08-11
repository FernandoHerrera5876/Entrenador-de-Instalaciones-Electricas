using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Cambia a una escena por su nombre
    public void CambiarEscena(string nombreEscena)
    {
        Debug.Log($"Cargando escena:{nombreEscena}");
        SceneManager.LoadScene(nombreEscena);
    }

    // Cierra la aplicación (útil para botones de "Salir")
    public void SalirDelJuego()
    {
        Debug.Log("Cerrando la aplicación");
        Application.Quit();
    }
}