using UnityEngine;

public class ExpandibleUIConControl : MonoBehaviour
{
    private Vector3 originalPosition;
    private Vector3 originalScale;
    private Quaternion originalRotation;
    private Transform originalParent;
    private bool isExpanded = false;

    [Header("Configuración")]
    public Transform xrCamera; // Asigna la Main Camera
    public Vector3 offset = new Vector3(0f, 0.3f, 1.5f);
    public Vector3 expandedScale = new Vector3(2f, 2f, 2f);

    [Header("Otras pancartas a ocultar")]
    public GameObject[] otrasPancartas; // Asigna aquí las otras pancartas

    void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;
        originalRotation = transform.rotation;
        originalParent = transform.parent;

        if (xrCamera == null)
        {
            Camera mainCam = Camera.main;
            if (mainCam != null)
                xrCamera = mainCam.transform;
        }
    }

    public void OnSelected()
    {
        if (xrCamera == null) return;

        if (!isExpanded)
        {
            // Expandir frente al jugador
            transform.position = xrCamera.position + xrCamera.forward * offset.z + xrCamera.up * offset.y + xrCamera.right * offset.x;
            transform.rotation = Quaternion.LookRotation(transform.position - xrCamera.position);
            transform.localScale = expandedScale;

            // Desactivar las demás pancartas
            foreach (GameObject pancarta in otrasPancartas)
            {
                if (pancarta != null && pancarta != this.gameObject)
                    pancarta.SetActive(false);
            }

            isExpanded = true;
        }
        else
        {
            // Contraer y volver a posición original
            transform.position = originalPosition;
            transform.rotation = originalRotation;
            transform.localScale = originalScale;

            // Reactivar las demás pancartas
            foreach (GameObject pancarta in otrasPancartas)
            {
                if (pancarta != null && pancarta != this.gameObject)
                    pancarta.SetActive(true);
            }

            isExpanded = false;
        }
    }
}
