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
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey;


    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;

    void Start()
    {
        characterController = GetComponent<CharacterController>();


        //rb.freezeRotation = true;

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
        //SpeedControl();

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * playerSpeed);

        if(move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if(Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

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

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && groundedPlayer)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    /*private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(characterController.velocity.x, 0f, characterController.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            characterController.velocity = new Vector3(limitedVel.x, characterController.velocity.y, limitedVel.z);
        }
    }*/

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (groundedPlayer)
            characterController.Move(moveDirection.normalized * playerSpeed);

        // in air
        else if (!groundedPlayer)
            characterController.Move(moveDirection.normalized * playerSpeed * airMultiplier);
    }

    private void Jump()
    {
        // reset y velocity
        playerVelocity = new Vector3(characterController.velocity.x, 0f, characterController.velocity.z);

        characterController.Move(transform.up * jumpForce);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
