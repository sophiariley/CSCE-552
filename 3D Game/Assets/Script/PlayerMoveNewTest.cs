using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveNewTest : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;

    public float speed = 6f;
    public float sprintSpeed = 12f;
    public float smoothTurninTime = 0.1f;
    float smoothTurninVelocity;

    public float jumpHeight = 3f;
    public float gravity = -9.8f;

    private bool isGrounded;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    private Vector3 velocity;

    void Update()
    {
        CheckGrounded();
        BroadcastMessage("isGrounded", isGrounded);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurninVelocity, smoothTurninTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

            controller.Move(currentSpeed * Time.deltaTime * moveDirection.normalized);
        }

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Move the player
        controller.Move(velocity * Time.deltaTime);
    }

    void CheckGrounded()
    {

    
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset velocity when grounded to prevent accumulating gravity
        }
        // TESTING
        // Debug.Log("Ground Distance: " + groundDistance);
        // Debug.Log("Is Grounded: " + isGrounded);
        // TESTING


    }
}
