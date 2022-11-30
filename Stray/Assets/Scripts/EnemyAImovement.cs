using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAImovement : MonoBehaviour
{
    public Transform playerObj;
    private NavMeshAgent enemyMesh;
    

    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
        playerObj = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        GetComponent<NavMeshAgent>().speed = 3;
        enemyMesh.SetDestination(playerObj.position);
        float dist = Vector3.Distance(playerObj.position, transform.position);
        if(dist <= 5f)
        {
            GetComponent<NavMeshAgent>().speed = 9;
        }
    }
}
