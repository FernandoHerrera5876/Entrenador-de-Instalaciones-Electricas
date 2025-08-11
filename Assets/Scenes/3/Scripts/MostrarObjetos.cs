using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("Objetos que se deben activar")]
    public GameObject[] objetosAMostrar;

    [Header("Script que gestiona la restauración de posiciones")]
    public DesactivarObjetosAlPresionar desactivador;  // Referencia al script DesactivarObjetosAlPresionar

    public void MostrarObjetos()
    {
        Debug.Log("🟢 Botón presionado: mostrando objetos.");

        // Restaurar las posiciones de los objetos antes de activarlos
        desactivador.RestaurarPosicionYRotacion();

        // Activar los objetos
        foreach (GameObject obj in objetosAMostrar)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }
}
