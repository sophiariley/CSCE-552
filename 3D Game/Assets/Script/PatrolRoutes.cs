using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRoutes : MonoBehaviour
{
    public Transform[] waypoints;
    private int _currentWaypoint;
    public float _speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform current = waypoints[_currentWaypoint];
        if (Vector3.Distance(transform.position, current.position) < 0.01f) {
            _currentWaypoint = (_currentWaypoint + 1) % waypoints.Length;
        } else {
            transform.LookAt(current);
            transform.position = Vector3.MoveTowards(transform.position, current.position, _speed * Time.deltaTime);
        }
    }
}
