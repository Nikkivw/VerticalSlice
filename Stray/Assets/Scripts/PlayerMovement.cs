using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 velocity;
    [SerializeField] private int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        velocity.x = 0;
        velocity.z = 0;
        velocity.y = 0;
        if (Input.GetKey(KeyCode.A))
        {
            velocity.z = -speed;
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity.z = speed;
            
        }
        if (Input.GetKey(KeyCode.W))
        {
            velocity.x = -speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.x = speed;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            velocity.y = speed;
        }
    }
}
