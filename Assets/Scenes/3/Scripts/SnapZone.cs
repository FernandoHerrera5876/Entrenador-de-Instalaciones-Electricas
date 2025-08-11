using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapZone : MonoBehaviour
{
    [Header("Punto de encaje (puede dejarse vacío si no se alinea forzadamente)")]
    public Transform puntoDeEncaje;

    [Header("Nombre exacto del objeto que debe encajar aquí")]
    public string nombreEsperado;

    private void OnTriggerStay(Collider other)
    {
        // Verificamos que tenga la Tag correcta
        if (other.CompareTag("Encajable"))
        {
            XRGrabInteractable grab = other.GetComponent<XRGrabInteractable>();

            // Solo si el objeto ya fue soltado y aún puede interactuar
            if (grab != null && !grab.isSelected && grab.enabled)
            {
                // Verificar que el nombre coincida con el nombre esperado
                if (other.name != nombreEsperado)
                    return; // ❌ No es el objeto correcto, no hacemos nada

                // ✅ Es el objeto correcto → continuar con encaje

                // Si quieres encajarlo en una posición exacta, descomenta lo siguiente:
                other.transform.position = puntoDeEncaje.position;
                other.transform.rotation = puntoDeEncaje.rotation;

                // Desactivar físicas
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.isKinematic = true;

                // Desactivar el agarre
                grab.enabled = false;

                // OPCIONAL: puedes agregar efectos aquí (sonido, partículas, etc.)
            }
        }
    }
}
