using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // Array of waypoints to follow
    public Transform[] waypoints;

    // Speed at which to move
    public float speed = 2.0f;

    // Index of current waypoint
    private int waypointIndex = 0;
    public GameObject Cat;
    // Flag to track whether the player is following waypoints or not
    public bool followingWaypoints = false;

    private void OnTriggerEnter(Collider other)
    {
        // If the player enters the collider, start following the waypoints
        if (other.gameObject.tag == "Jump1" || Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Test");
            followingWaypoints = true;
            //checkwaypoint();
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if(followingWaypoints == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<PlayerMovement>().enabled = false;
            checkwaypoint();
        }
        
    }
    void checkwaypoint()
    {
        // Get the current waypoint
        Transform targetWaypoint = waypoints[waypointIndex];
        // Move towards the waypoint
        Cat.transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
        // If the player has reached the waypoint, move to the next one
        if (transform.position == targetWaypoint.position)
        {
            waypointIndex++;
        }
        // If the player has reached the end of the waypoints, allow them to move freely
        if (waypointIndex >= waypoints.Length)
        {
            followingWaypoints = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<PlayerMovement>().enabled = true;
            waypointIndex = 0;
            
        }
        
    }
}
