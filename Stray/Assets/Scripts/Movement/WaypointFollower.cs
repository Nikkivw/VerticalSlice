using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // Array of waypoints to follow
    public Transform[] waypoints1;
    public Transform[] waypoints2;
    public Transform[] waypoints3;
    public Transform[] waypoints4;
    public GameObject Cat;
    // Speed at which to move
    public float speed = 2.0f;

    // Index of current waypoint
    private int waypointIndex = 0;

    // Flag to track whether the player is following waypoints or not
    public bool followingWaypoints = false;

    private void OnTriggerStay(Collider other)
    {
        // If the player enters the collider, start following the waypoints
        if (other.gameObject.tag == "Jump1" && Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Test");
            followingWaypoints = true;
            
        }
        if (other.gameObject.tag == "Jump2" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Test");
            followingWaypoints = true;

        }
        if (other.gameObject.tag == "Jump3" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Test");
            followingWaypoints = true;

        }
        if (other.gameObject.tag == "Jump4" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Test");
            followingWaypoints = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(followingWaypoints == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<PlayerMovement>().enabled = false;
            checkWaypoint();
        }
        
    }
    void checkWaypoint()
    {
        // Get the current waypoint
        Transform targetWaypoint = waypoints1[waypointIndex];
        // Move towards the waypoint
        Cat.transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
        // If the player has reached the waypoint, move to the next one
        if (transform.position == targetWaypoint.position)
        {
            waypointIndex++;
        }
        // If the player has reached the end of the waypoints, allow them to move freely
        if (waypointIndex >= waypoints1.Length)
        {
            followingWaypoints = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<PlayerMovement>().enabled = true;
            waypointIndex = 0;

        }
    }
}
