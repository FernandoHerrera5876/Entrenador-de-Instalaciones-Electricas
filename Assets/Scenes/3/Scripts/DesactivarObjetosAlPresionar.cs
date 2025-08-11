using UnityEngine;

public class DesactivarObjetosAlPresionar : MonoBehaviour
{
    [Header("Objetos a desactivar")]
    public GameObject[] objetosADesactivar;

    // Arreglos para guardar la posición y rotación inicial de los objetos
    private Vector3[] posicionesIniciales;
    private Quaternion[] rotacionesIniciales;

    void Start()
    {
        // Inicializamos los arreglos con la misma cantidad de objetos
        posicionesIniciales = new Vector3[objetosADesactivar.Length];
        rotacionesIniciales = new Quaternion[objetosADesactivar.Length];

        // Guardamos la posición y rotación inicial de cada objeto
        for (int i = 0; i < objetosADesactivar.Length; i++)
        {
            if (objetosADesactivar[i] != null)
            {
                posicionesIniciales[i] = objetosADesactivar[i].transform.position;
                rotacionesIniciales[i] = objetosADesactivar[i].transform.rotation;
            }
        }
    }

    public void DesactivarObjetos()
    {
        foreach (GameObject obj in objetosADesactivar)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }

    // Método para restaurar la posición y rotación cuando se reactiva
    public void RestaurarPosicionYRotacion()
    {
        for (int i = 0; i < objetosADesactivar.Length; i++)
        {
            if (objetosADesactivar[i] != null)
            {
                objetosADesactivar[i].transform.position = posicionesIniciales[i];
                objetosADesactivar[i].transform.rotation = rotacionesIniciales[i];
            }
        }
    }
}
