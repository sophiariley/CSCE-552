using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public GameObject targetPrefab;
    public float Distance_;
    public AudioSource myAudioSource;
    private float myAudioValumn;


    // Start is called before the first frame update
    void Start()
    {
        myAudioValumn = 0.5f;
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.Play();
    }

        // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Distance_ = Vector3.Distance(targetPrefab.transform.position, mousePos) * 10;

        if (Distance_ < 105)
        {
            Debug.Log("Touch!!");
            myAudioSource.volume = 1;

        }
        else if (Distance_ < 110)
        {
            Debug.Log("Very CLOSE");
            myAudioSource.volume = 0.80f;
        }
        else if (Distance_ < 120)
        {
            Debug.Log("NOT SO CLOSE");
            myAudioSource.volume = 0.6f;
        }
        else if (Distance_ < 130)
        {
            myAudioSource.volume = 0.4f;
        }
        else
        {
            Debug.Log("FAR!!");
            myAudioSource.volume = 0.2f;
        }


    }
    
}

