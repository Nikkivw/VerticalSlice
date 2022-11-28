using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float range;
    [SerializeField] private float lungerange;
    [SerializeField] private Transform target;
    
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        
        float dist = Vector3.Distance(target.position, transform.position);
        if (dist <= lungerange)
        {
            transform.LookAt(target);
            speed = 10;
            transform.position += transform.forward * speed * Time.deltaTime;
            if(dist <= 0.1f)
            {
                Destroy(gameObject);
            }
        }
        if (dist <= range)
        {
            speed = 5;
            transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
            speed = 0;
    }
}
