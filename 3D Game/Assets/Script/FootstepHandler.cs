using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepHandler : MonoBehaviour
{
    public AudioSource footstepsSound, sprintSound, jumpSound;

    void Update()
    {
        // Whenever the player moves (using W, A, S, or D), the footstep sound should play
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // If the player is sprinting (using left shift), the sprinting sound should play instead
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                footstepsSound.enabled = false;
                sprintSound.enabled = true;
                jumpSound.enabled = false;
                if (Input.GetKey(KeyCode.Space))
                {
                    jumpSound.enabled = true;
                    footstepsSound.enabled = false;
                    sprintSound.enabled = false;
                }
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                jumpSound.enabled = true;
                footstepsSound.enabled = false;
                sprintSound.enabled = false;
            }
            else
            {
                footstepsSound.enabled = true;
                sprintSound.enabled = false;
                jumpSound.enabled = false;
            }
        }

        else if (Input.GetKey(KeyCode.Space))
        {
            jumpSound.enabled = true;
            footstepsSound.enabled = false;
            sprintSound.enabled = false;
        }

        // If the player isn't moving, no sound should be played
        else
        {
            footstepsSound.enabled = false;
            sprintSound.enabled = false;
            jumpSound.enabled = false;
        }
    }

}
