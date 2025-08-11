using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aparicion2 : MonoBehaviour
{
    public GameObject objeto1; // Asegúrate de asignar el primer GameObject en el Inspector de Unity
    public GameObject objeto2; // Asegúrate de asignar el segundo GameObject en el Inspector de Unity

    private void Start()
    {
        if (objeto1 != null)
        {
            objeto1.SetActive(false); // Desactiva el primer GameObject al inicio
            UnityEngine.Debug.Log("Primer GameObject desactivado al inicio.");
        }
        else
        {
            UnityEngine.Debug.LogError("Primer GameObject no asignado en " + gameObject.name);
        }

        if (objeto2 != null)
        {
            objeto2.SetActive(false); // Desactiva el segundo GameObject al inicio
            UnityEngine.Debug.Log("Segundo GameObject desactivado al inicio.");
        }
        else
        {
            UnityEngine.Debug.LogError("Segundo GameObject no asignado en " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el collider tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            if (objeto1 != null)
            {
                objeto1.SetActive(true); // Activa el primer GameObject
                UnityEngine.Debug.Log("Player ha colisionado con " + gameObject.name + ". Primer GameObject activado.");
            }
            else
            {
                UnityEngine.Debug.LogError("Primer GameObject no asignado en " + gameObject.name);
            }

            if (objeto2 != null)
            {
                objeto2.SetActive(true); // Activa el segundo GameObject
                UnityEngine.Debug.Log("Player ha colisionado con " + gameObject.name + ". Segundo GameObject activado.");
            }
            else
            {
                UnityEngine.Debug.LogError("Segundo GameObject no asignado en " + gameObject.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el collider tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            if (objeto1 != null)
            {
                objeto1.SetActive(false); // Desactiva el primer GameObject
                UnityEngine.Debug.Log("Player ha salido de la colisión con " + gameObject.name + ". Primer GameObject desactivado.");
            }

            if (objeto2 != null)
            {
                objeto2.SetActive(false); // Desactiva el segundo GameObject
                UnityEngine.Debug.Log("Player ha salido de la colisión con " + gameObject.name + ". Segundo GameObject desactivado.");
            }
        }
    }
}
