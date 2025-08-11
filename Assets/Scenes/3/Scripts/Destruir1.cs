using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisionó tiene un Transform
        if (other.GetComponent<Transform>() != null)
        {
            // Destruye el objeto que colisionó
            Destroy(other.gameObject);
        }
    }
}
