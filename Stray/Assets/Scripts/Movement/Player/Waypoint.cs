using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform[] pointsJumpOne;
    public Transform[] pointsJumpTwo;
    public Transform[] pointsJumpThree;
    public Transform[] pointsJumpFour;
    [SerializeField] private Transform player;
    private Transform target;
    private int waypointindex1 = 0;
    private string moveTag = "Jump1";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        target = pointsJumpOne[waypointindex1]; 
            if (collision.gameObject.tag == moveTag && Input.GetKeyDown(KeyCode.Space))
            {
                pointsJumpOne = new Transform[transform.childCount];
                for (int i = 0; i < pointsJumpOne.Length; i++)
                {
                    pointsJumpOne[i] = transform.GetChild(i);
                }
                Vector3 dir = target.position - transform.position;
                transform.Translate(dir.normalized * GetComponent<PlayerMovement>().speed * Time.deltaTime, Space.World);
                if (Vector3.Distance(transform.position, target.position) <= 0.3f)
                {
                    GetNextWaypoint();
                    if (waypointindex1 == 5)
                    {
                        target = player;
                    }
                }
            }
    }
    void GetNextWaypoint()
    {
        
        if (waypointindex1 + 1 < pointsJumpOne.Length)
        {
            waypointindex1++;
            target = pointsJumpOne[waypointindex1];

        }
    }
        void Update()
    {
        
    }
    


    private void Awake()
    {
        
       /* pointsJumpTwo = new Transform[transform.childCount];
        for (int i = 0; i < pointsJumpOne.Length; i++)
        {
            pointsJumpTwo[i] = transform.GetChild(i);
        }
        pointsJumpThree = new Transform[transform.childCount];
        for (int i = 0; i < pointsJumpOne.Length; i++)
        {
            pointsJumpThree[i] = transform.GetChild(i);
        }
        pointsJumpFour = new Transform[transform.childCount];
        for (int i = 0; i < pointsJumpOne.Length; i++)
        {
            pointsJumpFour[i] = transform.GetChild(i);
        }*/
    }
}
