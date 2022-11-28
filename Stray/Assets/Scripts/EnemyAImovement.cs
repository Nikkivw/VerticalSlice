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
        enemyMesh.SetDestination(playerObj.position);
    }
}
