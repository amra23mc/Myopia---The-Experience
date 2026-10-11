// using UnityEngine;
// using UnityEngine.InputSystem;
//
// public class CharacterController : MonoBehaviour
// {
//     private CharacterController controller;
//     private Vector3 playerVelocity;
//     private bool groundedPlayer;
//     private float playerSpeed = 2.0f;
//     private float jumpHeight = 1.0f;
//     private float gravityValue = -9.81f;
//     
//
//     private void Awake()
//     {
//         controller = GetComponent<CharacterController>();
//     }
//
//     private void OnEnable()
//     {
//         moveAction.action.Enable();
//         jumpAction.action.Enable();
//     }
//
//     private void OnDisable()
//     {
//         moveAction.action.Disable();
//         jumpAction.action.Disable();
//     }
//
//     void Update()
//     {
//         groundedPlayer = controller.isGrounded;
//         if (groundedPlayer && playerVelocity.y < 0)
//         {
//             playerVelocity.y = 0f;
//         }
//         
//         Vector3 move = new Vector3(input.x, 0, input.y);
//         controller.Move(move * Time.deltaTime * playerSpeed);
//
//         if (move != Vector3.zero)
//         {
//             gameObject.transform.forward = move;
//         }
//
//         // Jump
//         if (jumpAction.action.triggered && groundedPlayer)
//         {
//             playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
//         }
//
//         // Apply gravity
//         playerVelocity.y += gravityValue * Time.deltaTime;
//
//         // Combine horizontal and vertical movement
//         Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
//         controller.Move(finalMove * Time.deltaTime);
//     } 
// }
