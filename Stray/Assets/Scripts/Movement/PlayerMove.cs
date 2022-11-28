using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeedF = 5.0f;
    public float moveSpeedB = 5.0f;
    public float moveSpeedL = 5.0f;
    public float moveSpeedR = 5.0f;

    public float rotationSpeed = 15;

    public Transform Front;
    public Transform Back;
    public Transform Left;
    public Transform Right;

    GameObject moveW;
    GameObject moveS;
    GameObject moveA;
    GameObject moveD;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(-moveSpeedF, 0, 0);
            //transform.LookAt(Front);

           Instantiate(moveW, transform.position, transform.rotation);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(moveSpeedB, 0, 0);
            //transform.LookAt(Back);

            Instantiate(moveS, transform.position, transform.rotation);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(0, 0, -moveSpeedL);
            //transform.LookAt(Left);

            Instantiate(moveA, transform.position, transform.rotation);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0, 0, moveSpeedR);
            //transform.LookAt(Right);

            Instantiate(moveD, transform.position, transform.rotation);
        }
    }
}
