using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public float speed = 1f; // Velocidad de la cinta transportadora
    public Vector3 direction = Vector3.forward; // Dirección de la cinta transportadora
    private List<Rigidbody> onBelt = new List<Rigidbody>(); // Lista de objetos sobre la cinta transportadora

    // FixedUpdate es mejor para trabajar con físicas
    void FixedUpdate()
    {
        foreach (Rigidbody rb in onBelt)
        {
            rb.velocity = speed * direction;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Añadir a la lista solo si el objeto tiene un Rigidbody
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null && !onBelt.Contains(rb))
        {
            onBelt.Add(rb);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Quitar de la lista si el objeto tiene un Rigidbody
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null && onBelt.Contains(rb))
        {
            onBelt.Remove(rb);
        }
    }
}
