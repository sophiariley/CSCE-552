using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(playerAnimator != null)

        // walking
        if(Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.D))
            {
                playerAnimator.SetBool("walking", true);
            }
        if(Input.GetKeyUp(KeyCode.W)
            || Input.GetKeyUp(KeyCode.A)
            || Input.GetKeyUp(KeyCode.S)
            || Input.GetKeyUp(KeyCode.D))
            {
                playerAnimator.SetBool("walking", false);
            }

        // jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("jump");
        }

        // swipe
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAnimator.SetTrigger("swipe");
        }

        // blocking
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            playerAnimator.SetBool("blocking", true);
        }
        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            playerAnimator.SetBool("blocking", false);
        }
    }

    void isGrounded(bool isGrounded) {
        playerAnimator.SetBool("isGrounded",isGrounded);
    }
}
