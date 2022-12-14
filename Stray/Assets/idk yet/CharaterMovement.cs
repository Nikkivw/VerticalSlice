using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaterMovement : MonoBehaviour
{
    // variable to store character animator component
    Animator animator;

    // variables to store optimized setter/getter parameter IDs
    int isWalkingHash;
    int isRunningHash;

    // variable to store instance of the PlayerInput
    PlayerInput input;

    //variables to store player input values
    Vector2 currentMovement;
    bool movementPressed;
    bool runPressed;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        //Debug.Log("Hallo");
        input = new PlayerInput();

        
        // set the player input values using listeners
        input.CharacterControls.Movement.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };

        input.CharacterControls.Run.performed += ctx => runPressed = ctx.ReadValueAsButton();
    }

    // Start is called before the first frame update
    void Start()
    {
        // set the animator reference


        animator = GetComponent<Animator>();
        Debug.Log("!!!");

        // set the ID references
        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");

        Debug.Log("walk id" + isWalkingHash + "runId" + isRunningHash);
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
        handleRotation();
    }

    void handleRotation()
    {
        // Current position of our character
        Vector3 currentPosition = transform.position;

        // the change in position our character should point to
        Vector3 newPosition = new Vector3(currentMovement.x, 0, currentMovement.y);

        // combine the positions to give a position to look at
        Vector3 positionToLookAt = currentPosition + newPosition;

        // rotate the character to face the positionToLookAt
        transform.LookAt(positionToLookAt);
    }

    void handleMovement()
    {

        //Debug.Log("dfghj" + isRunningHash);
        // get parameter values from animator

        Debug.Log("animator" + animator);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);

        // start walking if movement pressed is true and not already walking
        if (movementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }

        // stop walking if movementPressed is dalse and not already walking
        if (!movementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        // start running if movement pressed and run pressed is true and not already running
        if ((movementPressed && runPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }

        // stop running if movement pressed or run pressed is false and currently running
        if ((!movementPressed || !runPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    void OnEnable()
    {
        // enable the character controls action map
        input.CharacterControls.Enable();
    }

    void OnDisable()
    {
        // disable the character controls action map
        input.CharacterControls.Disable();
    }
}
