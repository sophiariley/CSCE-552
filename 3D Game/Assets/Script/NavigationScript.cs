using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance (player.transform.position, transform.position);
        Debug.Log("Distance: " + distance);
        if (distance <= 30) 
        {
            agent.destination = player.position;

        }
        
    }
}
