using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerTeleportButton : MonoBehaviour
{
    public FadeTeleport fadeTeleport;
    public InputActionProperty teleportButton;

    void OnEnable() => teleportButton.action.Enable();
    void OnDisable() => teleportButton.action.Disable();

    void Update()
    {
        if (teleportButton.action.WasPressedThisFrame())
        {
            fadeTeleport.StartTeleport();
        }
    }
}