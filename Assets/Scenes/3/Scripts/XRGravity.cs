using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class XRGravity : MonoBehaviour
{
    public float gravity = -30f;
    public float groundCheckDistance = 0.2f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // pequeño valor para mantener contacto con el suelo
        }

        // Acumular gravedad si no está tocando el suelo
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}