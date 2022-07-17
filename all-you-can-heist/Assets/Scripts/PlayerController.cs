using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;
    Animator animator;

    int isWalkingHash;

    Vector2 currentMovementInput;
    Vector3 currtentMovement;
    Vector3 appliedMovement;

    bool isMovementPressed;
    float rotationFactorPerFrame = 15.0f;
    float runMultiplier = 8.0f;
    float walkMultiplier = 4.0f;
    float groundedGravity = -0.5f;
    float gravity = -9.8f;


    private void Awake()
    {

        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

       isWalkingHash = Animator.StringToHash("IsWalking");

        playerInput.CharacterControls.Move.started += context => {
            OnMovementInput(context);
        };
        playerInput.CharacterControls.Move.canceled += context => {
            OnMovementInput(context);
        };
        playerInput.CharacterControls.Move.performed += context => {
            OnMovementInput(context);
        };
    }


    


    void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        //currtentMovement.x = currentMovementInput.x * runMultiplier;
       // currtentMovement.z = currentMovementInput.y * runMultiplier;
        currtentMovement.x = currentMovementInput.x * walkMultiplier;
        currtentMovement.z = currentMovementInput.y * walkMultiplier;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }
    void HandleGravity()
    {
        bool isFalling = currtentMovement.y <= 0.0f;
        float fallingMultiplier = 2.0f;
        if (characterController.isGrounded)
        {
            appliedMovement.y = groundedGravity;
        }
        else if(isFalling)
        {
            float previousYVelocity = currtentMovement.y;
            currtentMovement.y = currtentMovement.y + (gravity * fallingMultiplier * Time.deltaTime);
            appliedMovement.y = (previousYVelocity + currtentMovement.y) * 0.5f;
        }else
        {
            float previousYVelocity = currtentMovement.y;
            currtentMovement.y = currtentMovement.y + (gravity * Time.deltaTime);
            appliedMovement.y = (previousYVelocity + currtentMovement.y) * 0.5f;
        }
    }
    void HandleAnimation()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        if(isMovementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }else if(!isMovementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);

        }
    }

    void HandleRotation()
    {
        Vector3 positionLookAt;
        positionLookAt.x = currtentMovement.x;
        positionLookAt.y = 0.0f;
        positionLookAt.z = currtentMovement.z;

        Quaternion currentRotation = transform.rotation;
        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
            HandleAnimation();
            HandleRotation();
            appliedMovement.x = currtentMovement.x;
            appliedMovement.z = currtentMovement.z;
            characterController.Move(appliedMovement * Time.deltaTime);

            HandleGravity();
        
    }
    private void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }
    private void OnDisable()
    {
        playerInput.CharacterControls.Disable();
    }

}
