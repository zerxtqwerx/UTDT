using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController_Movement_Mobile : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] public Button jumpButton;

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
        if (groundedPlayer && playerVelocity.y < 0)
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
        horizontalInput = joystick.Horizontal;
        verticalInput = joystick.Vertical;

    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        characterController.Move(moveDirection.normalized * playerSpeed);
    }

    public void Jump()
    {
        playerVelocity.y -= gravityValue * Time.deltaTime;

        characterController.Move(transform.up.normalized * jumpForce);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
