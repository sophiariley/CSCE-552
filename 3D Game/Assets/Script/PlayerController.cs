using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    public float speed = 5f;
    public float sprintSpeed = 10f;
    public float rotationSpeed = 10f;
    public float jumpHeight = 2f;
    public float gravity = 9.81f;

    private Vector3 velocity;

    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the character is grounded
        isGrounded = characterController.isGrounded;

        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = transform.TransformDirection(movement);

        // Check for sprint input
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        // Move the character
        characterController.Move(movement * currentSpeed * Time.deltaTime);

        // Rotate the character based on input
        transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);

        // Handle jumping
        if (isGrounded)
        {
            velocity.y = -2f; // Reset vertical velocity when grounded

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
            }
        }

        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;

        // Move the character vertically
        characterController.Move(velocity * Time.deltaTime);
    }
}
