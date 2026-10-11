using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Speed")]
    [SerializeField] float moveSpeed = 3.0f;
    
    [Header("Look Parameters")]
    [SerializeField] float mouseSensitivity = 1.5f;
    [SerializeField] float upDownLookRange = 80f;
    
    [Header ("References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera camera;
    [SerializeField] private PlayerInputHandler playerInputHandler;

    private Vector3 currentMovement;
    private float verticalRotation;
    
    public GameObject PostProcessing;
    public Animator animator;
    public AudioSource starving;
    public AudioSource jake;
    public AudioSource end;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blind"))
        {
            PostProcessing.SetActive(false);
            moveSpeed = 3.5f;
            mouseSensitivity = 1.1f;
            animator.SetTrigger("Start");
            jake.Pause();
            starving.Play();
        }

        if (other.gameObject.CompareTag("End"))
        {
            end.Play();
        }
    }

    private Vector3 CalculateWorldDirection()
    {
        Vector3 inputDirection =
            new Vector3(playerInputHandler.movementInput.x, 0f, playerInputHandler.movementInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        return worldDirection.normalized;
    }

    private void HandleMovement()
    {
        Vector3 worldDirection = CalculateWorldDirection();
        currentMovement.x = worldDirection.x * mouseSensitivity;
        currentMovement.z = worldDirection.z * mouseSensitivity;
        
        characterController.Move(currentMovement * Time.deltaTime * moveSpeed);
    }

    private void ApplyHorizontalRotation(float rotationAmount)
    {
        transform.Rotate(0, rotationAmount, 0);
    }

    private void ApplyVerticalRotation(float rotationAmount)
    {
        verticalRotation = Mathf.Clamp(verticalRotation - rotationAmount, -upDownLookRange, upDownLookRange);
        camera.transform.localRotation= Quaternion.Euler(verticalRotation, 0, 0);
    }

    private void HandleRotation()
    {
        float mouseXRotation = playerInputHandler.lookInput.x * mouseSensitivity;
        float mouseYRotation = playerInputHandler.lookInput.y * mouseSensitivity;
        
        ApplyHorizontalRotation(mouseXRotation);
        ApplyVerticalRotation(mouseYRotation);
    }

}
