using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public string gameScene;
    public string creditMenu;
    public string instructionMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void continueGame()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(gameScene);

               
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == gameScene)
        {
            // Now the scene is fully loaded

            // Find the GameObject with the SecondSceneScript component in the loaded scene
            GameObject secondSceneObject = GameObject.FindWithTag("Player");

            if (secondSceneObject != null)
            {
                // Get the SecondSceneScript component
                Player secondSceneScript = secondSceneObject.GetComponent<Player>();

                if (secondSceneScript != null)
                {
                    // Call the function in SecondSceneScript
                    secondSceneScript.LoadPlayer();
                }
                else
                {
                    Debug.LogError("SecondSceneScript component not found on the GameObject in the second scene.");
                }
            }
            else
            {
                Debug.LogError("GameObject with the name 'SecondSceneObject' not found in the second scene.");
            }
        }
    }

        
    

    public void quitGame()
    {
        Application.Quit();
    }


}
