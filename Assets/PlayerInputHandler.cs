using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;
    
    [Header("Action Map Name Reference")]
    [SerializeField] private string actionMapName = "Player";
    
    [Header("Action Name References")]
    [SerializeField] private string movement = "Move";
    [SerializeField] private string look = "Look";
    [SerializeField] private string interact = "Interact";
    
    private InputAction movementAction;
    private InputAction lookAction;
    private InputAction interactAction;
    
    public Vector2 movementInput {get; private set;}
    public Vector2 lookInput {get; private set;}
    public bool interactTriggered {get; private set;}

    private void Awake()
    {
        InputActionMap mapReference = playerControls.FindActionMap(actionMapName);
        
        movementAction = mapReference.FindAction(movement);
        lookAction = mapReference.FindAction(look);
        interactAction = mapReference.FindAction(interact);
        
        SubscribeActionValuesToInputEvents();
    }

    private void SubscribeActionValuesToInputEvents()
    {
        movementAction.performed += inputInfo => movementInput = inputInfo.ReadValue<Vector2>();
        movementAction.canceled += inputInfo => movementInput = Vector2.zero;
        
        lookAction.performed += inputInfo => lookInput = inputInfo.ReadValue<Vector2>();
        lookAction.canceled += inputInfo => lookInput = Vector2.zero;
        
        interactAction.performed += inputInfo => interactTriggered = true; 
        interactAction.canceled += inputInfo => interactTriggered = false;
    }

    private void OnEnable()
    {
        playerControls.FindActionMap(actionMapName).Enable();
    }

    private void OnDisable()
    {
        playerControls.FindActionMap(actionMapName).Disable();
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }
}
