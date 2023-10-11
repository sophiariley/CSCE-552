using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public void QuitGame() {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Pause() {
        PauseGame();
    }

    public void Resume() {
        PauseGame();
    }

    void PauseGame() {
        paused = !paused;
        if (paused) {
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
    }


}
