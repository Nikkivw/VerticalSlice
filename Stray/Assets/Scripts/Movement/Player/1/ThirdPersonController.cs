using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    //input fields
    private ThirdPersonMovement playerActionsAsset;
    private InputAction move;

    public float lerpspeed = 1f;

    //movement fields
    private Rigidbody rb;
    [SerializeField]
    private float movementForce = 1f;
    [SerializeField]
    private float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField]
    private Camera playerCamera;
    private Animator animator;
     
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        playerActionsAsset = new ThirdPersonMovement();
        animator = this.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        move = playerActionsAsset.Player.Move;
        playerActionsAsset.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionsAsset.Player.Disable();
    }

    private void FixedUpdate()
    {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        //if (rb.velocity.y < 0f)
        //    rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        LookAt();
    }

    float step = 0.1f;
    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        //direction.y = 0f;
        //direction.z = 90f;

        Quaternion startRotation = rb.rotation;
        Quaternion endRotation = Quaternion.LookRotation(direction);

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            //var naam = new Vector3(0, 0, 0);
            //transform.rotation = Quaternion.LookRotation(direction);
            

            rb.rotation = Quaternion.Slerp(startRotation, endRotation, step);
            step += 0.1f * lerpspeed * Time.deltaTime;
        }
        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude < 0.1f)
        {
            step = 0.0f;
        }
        else
            rb.angularVelocity = Vector3.zero;

        

        //Vector3 direction = rb.velocity.normalized;
        //direction.y = 0f;

        //if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        //{
        //    transform.rotation = Quaternion.LookRotation(transform.position - direction, Vector3.up);
        //    Vector3 dir = Vector3.RotateTowards(transform.forward, transform.position - direction, 1000, 0.0f);
        //    transform.rotation = Quaternion.LookRotation(dir);
        //}
        //else
        //    rb.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

}