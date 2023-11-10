using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractFeedback : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log(Random.Range(0, 100));
        Debug.Log("Interaction Succeed");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
