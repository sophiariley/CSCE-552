using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    // Defining variables-- these can be edited directly from Unity
    [Header("References")]
    public Transform Orientation;
    public Transform Player;
    public Transform PlayerObject;
    public Rigidbody Rigidbody;

    public float RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Make cursor invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate where "forward" is
        Vector3 forwardDir = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        Orientation.forward = forwardDir.normalized;

        // Calculate input direction (i.e. rotate the player)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = Orientation.forward * verticalInput + Orientation.right * horizontalInput;
        
        // Change forwards direction of player object to input direction
        if(inputDir != Vector3.zero)
        {
            PlayerObject.forward = Vector3.Slerp(PlayerObject.forward, inputDir.normalized, Time.deltaTime * RotationSpeed);
        }
    }
}
