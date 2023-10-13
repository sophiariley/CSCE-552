using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{

    public AudioSource quitSound;
    
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
        StartCoroutine(quitAfterDelay(quitSound.clip.length));
        quitSound.Play();
    }

    private IEnumerator quitAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }

    public void goToTitleScreen() {
        //StartCoroutine(QuitAfterDelay(1f));
        
        SceneManager.LoadScene("TitleScreen");
    }
}
