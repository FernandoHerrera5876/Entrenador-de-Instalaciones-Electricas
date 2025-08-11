using UnityEngine;
using UnityEngine.InputSystem;

public class JumpWithCharacterController : MonoBehaviour
{
    public InputActionReference jumpAction; // Acción del Input System
    public CharacterController characterController;

    public float jumpForce = 5f;
    public float gravity = -9.81f;

    private float verticalVelocity = 0f;
    private bool isGrounded = false;

    void Update()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -1f; // pequeño valor negativo para mantener contacto con el suelo
        }

        // Detectar salto
        if (jumpAction.action.WasPressedThisFrame() && isGrounded)
        {
            verticalVelocity = jumpForce;
        }

        // Aplicar gravedad
        verticalVelocity += gravity * Time.deltaTime;

        // Movimiento vertical
        Vector3 move = new Vector3(0, verticalVelocity, 0);
        characterController.Move(move * Time.deltaTime);
    }
}