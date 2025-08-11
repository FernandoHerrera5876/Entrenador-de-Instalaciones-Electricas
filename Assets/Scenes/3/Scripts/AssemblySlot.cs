using UnityEngine;

public class PruebaTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("✅ Entró al trigger: " + other.name);
    }
}
