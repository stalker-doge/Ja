using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //input
    private InputActionAsset playerInputActions;
    private InputActionMap playerInputMap;
    private InputAction movement;


    //physics
    private Rigidbody rb;
    [SerializeField] float movementForce = 1f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float maxPumpSpeed = 1f;
    private Vector3 forceDirection = Vector3.zero;

    //pressure
    [SerializeField] public float pressure = 100f;
    [SerializeField] float pressureDrain = 2f;

    //Colliders
    [SerializeField] BoxCollider boxCollider;
    bool grounded;

    //other
    [SerializeField] Animator animator;

    private void Awake()
    {
        playerInputActions = this.GetComponent<PlayerInput>().actions;
        playerInputMap = playerInputActions.FindActionMap("Player");
        rb = this.GetComponent<Rigidbody>();
        LevelHandler.Instance.playersAlive++;
    }

    private void OnEnable()
    {
        movement = playerInputMap.FindAction("Movement");
        movement.Enable();
        playerInputMap.FindAction("Jump").started += DoJump;
        playerInputMap.FindAction("Pressure").started += RelievePressure;
        playerInputMap.Enable();
    }

    private void DoJump(InputAction.CallbackContext context)
    {
        if (grounded)
        {
            forceDirection += Vector3.up * jumpForce;
        }
    }

    private void OnDisable()
    {
       movement.Disable();
       playerInputMap.FindAction("Jump").started -= DoJump;
        playerInputMap.FindAction("Pressure").started -= RelievePressure;
        playerInputMap.Disable();
    }

    private void FixedUpdate()
    {
        //read input values
        forceDirection += movement.ReadValue<Vector2>().x *GameObject.Find("Camera").transform.right;
        forceDirection *= movementForce;

        //apply the force
        rb.AddForce(forceDirection, ForceMode.Impulse);
        //reset for next frame
        forceDirection = Vector3.zero;

        //extra gravity to feel less floaty?
        if (rb.velocity.y < 0)
            rb.velocity += Vector3.down * 10 * Time.fixedDeltaTime;

        //limit speed - but only in the horizontal
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        maxSpeed += Time.fixedDeltaTime;
        pressure -= Time.fixedDeltaTime*pressureDrain;

        if(pressure < 0)
        {
            KillPlayer();
        }
        if(rb.velocity.x>0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        if (rb.velocity.y > 0)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }

    }

    private void KillPlayer()
    {
        LevelHandler.Instance.playersAlive--;
        LevelHandler.Instance.LoadLose();
        Destroy(gameObject);

    }

    private void RelievePressure(InputAction.CallbackContext context)
    {

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;

        if(horizontalVelocity.sqrMagnitude < maxPumpSpeed)
        {
            if (pressure + 10 < 100)
                pressure += 10;
            else
                pressure = 100;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = true;

        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;

        }
    }
}
