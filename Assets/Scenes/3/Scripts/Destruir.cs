using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisionó tiene un BoxCollider
        if (other.GetComponent<BoxCollider>() != null)
        {
            // Destruye el objeto que colisionó
            Destroy(other.gameObject);
        }
    }
}
