using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame() {
        SceneManager.LoadScene("InGameScrene");
    }

    public void quitGame() {
        Application.Quit();
    }

    public void goToTitleScreen() {
        SceneManager.LoadScene("TitleScreen");
    }
}
