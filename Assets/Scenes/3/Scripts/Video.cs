using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Video : MonoBehaviour
{
    public GameObject objeto; // El GameObject que deseas activar/desactivar
    public Button boton; // El botón que usaremos para activar/desactivar el GameObject

    private void Start()
    {
        if (objeto != null)
        {
            objeto.SetActive(false); // Desactiva el GameObject al inicio
        }
        else
        {
            Debug.LogError("GameObject no asignado en " + gameObject.name);
        }

        if (boton != null)
        {
            boton.onClick.AddListener(ToggleObjeto); // Añade el listener al botón
        }
        else
        {
            Debug.LogError("Botón no asignado en " + gameObject.name);
        }
    }

    private void ToggleObjeto()
    {
        if (objeto != null)
        {
            objeto.SetActive(!objeto.activeSelf); // Activa/desactiva el GameObject
            Debug.Log("GameObject " + objeto.name + " está ahora " + (objeto.activeSelf ? "activado" : "desactivado") + " en " + gameObject.name);
        }
    }
}
