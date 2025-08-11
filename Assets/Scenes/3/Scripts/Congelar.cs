using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congelar : MonoBehaviour
{
   public bool freezeRotationX = false; // Congelar la rotación en el eje X
    public bool freezeRotationY = false; // Congelar la rotación en el eje Y
    public bool freezeRotationZ = false; // Congelar la rotación en el eje Z

    private void OnCollisionEnter(Collision collision)
    {
        // Obtén el Rigidbody del objeto colisionado
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Congela o descongela la rotación en los ejes especificados
            rb.freezeRotation = true; // Congela todas las rotaciones inicialmente

            Vector3 frozenAxes = Vector3.zero;
            if (freezeRotationX) frozenAxes.x = 1;
            if (freezeRotationY) frozenAxes.y = 1;
            if (freezeRotationZ) frozenAxes.z = 1;

            // Aplicar la configuración de congelación
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            if (!freezeRotationX) rb.constraints &= ~RigidbodyConstraints.FreezeRotationX;
            if (!freezeRotationY) rb.constraints &= ~RigidbodyConstraints.FreezeRotationY;
            if (!freezeRotationZ) rb.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
