using UnityEngine;
using UnityEngine.InputSystem;

public class JumpAction : MonoBehaviour
{
    public float jumpForce = 5f;
    public InputActionReference jumpButton;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        jumpButton.action.performed += ctx => Jump();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        if (isGrounded)
            velocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
    }

    void OnEnable() => jumpButton.action.Enable();
    void OnDisable() => jumpButton.action.Disable();
}