using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO:
// fix grounding
// enable jump
// enable sprint
public class PlayerMoveNewTest : MonoBehaviour
{

    public CharacterController controller;
    public Transform camera;
    //Rigidbody rb;

    public float speed = 6f;

    public float smoothTurninTime = 0.1f;
    float smoothTurninVelocity;


    // [Header("Ground Check")]
    // public float playerHeight;
    // public LayerMask whatIsGround;
    // bool grounded;

    // public float groundDrag;


    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
        // rb = GetComponent<Rigidbody>();
        // rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        // grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 1f + 0.3f, whatIsGround);
        // if (grounded)
        //     rb.drag = groundDrag;
        // else
        //     rb.drag = 0;


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3 (horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurninVelocity, smoothTurninTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(speed * Time.deltaTime * moveDirection.normalized);
        }
    }
}
