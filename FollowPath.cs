using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 2f;
    int waypointIndex = 0;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        Debug.Log(transform.position + ", " + waypoints[waypointIndex].transform.position);
        if(transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        
        }
        if(waypointIndex == waypoints.Length/*1*/)
        {
            waypointIndex = 0;
        }
    }
}

/******************************
 *https://youtu.be/ExRQAEm4jPg*
 ******************************/
