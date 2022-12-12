using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public static Transform[] pointsJumpOne;
    public static Transform[] pointsJumpTwo;
    public static Transform[] pointsJumpThree;
    public static Transform[] pointsJumpFour;
    [SerializeField] private Transform player;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * GetComponent<PlayerMovement>().speed * Time.deltaTime, Space.World);
    }
    


    private void Awake()
    {
        pointsJumpOne = new Transform[transform.childCount];
        for (int i = 0; i < pointsJumpOne.Length; i++)
        {
            pointsJumpOne[i] = transform.GetChild(i);
        }
    }
}
