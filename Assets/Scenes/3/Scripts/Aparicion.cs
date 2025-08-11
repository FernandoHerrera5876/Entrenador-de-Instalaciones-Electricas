using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aparicion : MonoBehaviour
{
    public GameObject objeto; // Asegúrate de asignar el GameObject en el Inspector de Unity

    private void Start()
    {
        if (objeto != null)
        {
            objeto.SetActive(false); // Desactiva el GameObject al inicio
            UnityEngine.Debug.Log("GameObject desactivado al inicio.");
        }
        else
        {
            UnityEngine.Debug.LogError("GameObject no asignado en " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el collider tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            if (objeto != null)
            {
                objeto.SetActive(true); // Activa el GameObject
                UnityEngine.Debug.Log("Player ha colisionado con " + gameObject.name + ". GameObject activado.");
            }
            else
            {
                UnityEngine.Debug.LogError("GameObject no asignado en " + gameObject.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el collider tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            if (objeto != null)
            {
                objeto.SetActive(false); // Desactiva el GameObject
                UnityEngine.Debug.Log("Player ha salido de la colisión con " + gameObject.name + ". GameObject desactivado.");
            }
        }
    }
}
