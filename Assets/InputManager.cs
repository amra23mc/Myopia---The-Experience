using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Input playerControls;

    private void Awake()
    {
        playerControls = new Input();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    
    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Move.ReadValue<Vector2>();
    }
    
    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }
    
    public bool PlayerInteract()
    {
        return playerControls.Player.Interact.triggered;
    }
}
