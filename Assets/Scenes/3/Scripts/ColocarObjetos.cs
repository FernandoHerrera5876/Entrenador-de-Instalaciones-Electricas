using UnityEngine;

public class SnapPiece : MonoBehaviour
{
    public Transform snapTarget;  // el lugar donde debe encajar
    public float snapRange = 0.5f; // distancia de "snap"

    private bool isSnapped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnapZone") && !isSnapped)
        {
            float distance = Vector3.Distance(transform.position, snapTarget.position);
            if (distance <= snapRange)
            {
                transform.position = snapTarget.position;
                transform.rotation = snapTarget.rotation; // opcional
                isSnapped = true;
            }
        }
    }
}
