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
    public Transform[] waypoints5;
    public float turnspeed = 0.1f;
    public GameObject Cat;
    // Speed at which to move
    public float speed = 2.0f;
    private Vector3 velocity;
    // Index of current waypoint
    private int waypointIndex = 0;

    // Flag to track whether the player is following waypoints or not
    public bool followingWaypoints1 = false;
    public bool followingWaypoints2 = false;
    public bool followingWaypoints3 = false;
    public bool followingWaypoints4 = false;
    public bool followingWaypoints5 = false;

    
    private void OnTriggerStay(Collider other)
    {
        // If the player enters the collider, start following the waypoints
        if (other.gameObject.tag == "Jump1" && Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Test");
            velocity.y = speed;
            followingWaypoints1 = true;
            
        }
        if (other.gameObject.tag == "Jump2" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Test");
            velocity.y = speed;
            followingWaypoints2 = true;

        }
        if (other.gameObject.tag == "Jump3" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Test");
            velocity.y = speed;
            followingWaypoints3 = true;

        }
        if (other.gameObject.tag == "Jump4" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Test");
            velocity.y = speed;
            followingWaypoints4 = true;

        }
        if (other.gameObject.tag == "Jump5" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Test");
            velocity.y = speed;
            followingWaypoints5 = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        velocity.x = 0;
        velocity.z = 0;
        velocity.y = 0;
        if (followingWaypoints1 == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<ThirdPersonController>().enabled = false;            
            checkWaypoints1();
        }
        if (followingWaypoints2 == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<ThirdPersonController>().enabled = false;
            checkWaypoints2();
        }
        if (followingWaypoints3 == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<ThirdPersonController>().enabled = false;
            checkWaypoints3();
        }
        if (followingWaypoints4 == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<ThirdPersonController>().enabled = false;
            checkWaypoints4();
        }
        if (followingWaypoints5 == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<ThirdPersonController>().enabled = false;
            checkWaypoints5();
        }
    }
    void checkWaypoints1()
    {
        // Get the current waypoint
        Transform targetWaypoint = waypoints1[waypointIndex];
        
        // Move towards the waypoint
        Cat.transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
        // If the player has reached the waypoint, move to the next one
        if (transform.position == targetWaypoint.position)
        {    
            Cat.transform.rotation = Quaternion.Euler(0, 160, 0);
            waypointIndex++;
        }
        // If the player has reached the end of the waypoints, allow them to move freely
        if (waypointIndex >= waypoints1.Length)
        {            
            followingWaypoints1 = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<ThirdPersonController>().enabled = true;
            waypointIndex = 0;
        }
    }
    void checkWaypoints2()
    {
        // Get the current waypoint
        Transform targetWaypoint = waypoints2[waypointIndex];
        // Move towards the waypoint
        Cat.transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
        // If the player has reached the waypoint, move to the next one
        if (transform.position == targetWaypoint.position)
        {
            waypointIndex++;
            transform.LookAt(targetWaypoint);
        }
        // If the player has reached the end of the waypoints, allow them to move freely
        if (waypointIndex >= waypoints2.Length)
        {
            followingWaypoints2 = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<ThirdPersonController>().enabled = true;
            waypointIndex = 0;
        }
    }
    void checkWaypoints3()
    {
        // Get the current waypoint
        Transform targetWaypoint = waypoints3[waypointIndex];
        // Move towards the waypoint
        Cat.transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
        // If the player has reached the waypoint, move to the next one
        if (transform.position == targetWaypoint.position)
        {
            waypointIndex++;
            transform.LookAt(targetWaypoint);
        }
        // If the player has reached the end of the waypoints, allow them to move freely
        if (waypointIndex >= waypoints3.Length)
        {
            Cat.transform.rotation = Quaternion.Euler(0, 270, 0);
            followingWaypoints3 = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<ThirdPersonController>().enabled = true;
            waypointIndex = 0;
        }
    }
    void checkWaypoints4()
    {
        // Get the current waypoint
        Transform targetWaypoint = waypoints4[waypointIndex];
        // Move towards the waypoint
        Cat.transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
        // If the player has reached the waypoint, move to the next one
        if (transform.position == targetWaypoint.position)
        {
            waypointIndex++;
            transform.LookAt(targetWaypoint);
        }
        // If the player has reached the end of the waypoints, allow them to move freely
        if (waypointIndex >= waypoints4.Length)
        {
            followingWaypoints4 = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<ThirdPersonController>().enabled = true;
            waypointIndex = 0;
        }
    }
    void checkWaypoints5()
    {
        // Get the current waypoint
        Transform targetWaypoint = waypoints5[waypointIndex];
        // Move towards the waypoint
        Cat.transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
        // If the player has reached the waypoint, move to the next one
        if (transform.position == targetWaypoint.position)
        {
            waypointIndex++;
            transform.LookAt(targetWaypoint);
        }
        // If the player has reached the end of the waypoints, allow them to move freely
        if (waypointIndex >= waypoints5.Length)
        {
            followingWaypoints5 = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<ThirdPersonController>().enabled = true;
            waypointIndex = 0;
        }
    }
}
