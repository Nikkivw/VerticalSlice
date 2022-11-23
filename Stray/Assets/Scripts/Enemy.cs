using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float range;
    [SerializeField] private Transform target;
    public string playerTag = "Player";
    
    void Start()
    {
        
    }

    void Update()
    {
        if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                GameObject target = GameObject.FindGameObjectWithTag(playerTag);
            }
        }

        float dist = Vector3.Distance(target.position, transform.position);
        if (dist <= range)
        {

            transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
