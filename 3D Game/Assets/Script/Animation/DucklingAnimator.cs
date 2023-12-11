using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucklingAnimator : MonoBehaviour
{
    public Animator ducklingAnimator;
    // Start is called before the first frame update
    void Start()
    {
        ducklingAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void pickedUp()
    {
        ducklingAnimator.SetTrigger("pickedUp");
    }
}
