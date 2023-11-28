using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMusicWithPause : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }
    public float playTime = 0.5f;
    public float pauseTime = 0.5f;
    private AudioSource music;

    void Start()
    {
        music = GetComponent<AudioSource>();
        StartCoroutine("PlayPauseCoroutine");
    }

    IEnumerator PlayPauseCoroutine()
    {
        while (true)
        {
            music.Play();
            yield return new WaitForSeconds(playTime);
            music.Pause();
            yield return new WaitForSeconds(pauseTime);
        }
    }
}
