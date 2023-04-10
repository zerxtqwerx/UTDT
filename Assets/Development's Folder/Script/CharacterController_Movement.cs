using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_Movement : MonoBehaviour
{
    CharacterController characterController;
    public Transform orientation;

    private Vector3 playerVelocity;

    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;

    private float gravityValue = -9.81f;

    public float jumpForce;
    public float jumpCooldown;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey;


    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    float directionY;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        readyToJump = true;
    }

    void Update()
    { 
        groundedPlayer = characterController.isGrounded;
        if(groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        MyInput();

        
        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if ((Input.GetKey(jumpKey) && readyToJump && groundedPlayer) && transform.position.y != jumpHeight)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);

        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        characterController.Move(moveDirection.normalized * playerSpeed);
    }

    private void Jump()
    {
        playerVelocity.y -= gravityValue * Time.deltaTime;

        characterController.Move(transform.up.normalized * jumpForce);

        
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
