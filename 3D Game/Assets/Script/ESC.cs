using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESC : MonoBehaviour
{
    // This method will be connected to the button's click event
    public void DoExitGame()
    {
        Application.Quit();
    }
}
