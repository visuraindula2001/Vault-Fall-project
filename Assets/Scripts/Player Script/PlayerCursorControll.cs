using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursorControl : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
    public bool walking;
    public Transform playerTrans;
    public Transform cameraTransform;

    public float mouseSensitivity = 100f;
    public float jumpForce = 5f;
    private float xRotation = 0f;

    public LayerMask groundMask; // Layer mask to detect ground
    private bool isGrounded;

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void Update()
    {
        HandleMouseLook();
        HandleAnimations();
        CheckGroundStatus();
    }

    // Handle physics-based player movement
    void HandleMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward * w_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward * wb_speed * Time.deltaTime;
        }

        // Apply movement while maintaining current vertical velocity
        Vector3 velocity = new Vector3(moveDirection.x, playerRigid.velocity.y, moveDirection.z);
        playerRigid.velocity = velocity;

        // Jumping with a ground check
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("jump");
        }
    }

    // Handle mouse movement for player rotation and camera pitch
    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        playerTrans.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    // Manage player animations using triggers
    void HandleAnimations()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            walking = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("walkback");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("walkback");
            playerAnim.SetTrigger("idle");
        }

        // Handle running when walking
        if (walking && Input.GetKeyDown(KeyCode.LeftShift))
        {
            w_speed += rn_speed;
            playerAnim.SetTrigger("run");
            playerAnim.ResetTrigger("walk");
        }
        if (walking && Input.GetKeyUp(KeyCode.LeftShift))
        {
            w_speed = olw_speed;
            playerAnim.ResetTrigger("run");
            playerAnim.SetTrigger("walk");
        }

        // Handle player rotation with A/D keys
        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }
    }

    // Check if the player is on the ground
    void CheckGroundStatus()
    {
        isGrounded = Physics.CheckSphere(playerTrans.position, 0.1f, groundMask);
    }
}
