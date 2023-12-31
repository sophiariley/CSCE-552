using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Vector3 _startPos;
    public bool _isFollowing = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance (player.transform.position, transform.position);
        if (Input.GetKeyDown("e") && distance < 3) {
            _isFollowing = true;
        } else if (_isFollowing == false) {
            agent.destination = _startPos;
            _isFollowing = false;
        }

        if (_isFollowing == true) {
            //Debug.Log("Distance: " + distance);
            agent.destination = player.position;
            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                transform.gameObject.GetComponent<NavMeshAgent>().speed = 10f;
            } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
                transform.gameObject.GetComponent<NavMeshAgent>().speed = 5f;
            }
        }
        
        
    }
}
