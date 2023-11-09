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
    private Vector3 forceDirection = Vector3.zero;

    private void Awake()
    {
        playerInputActions = this.GetComponent<PlayerInput>().actions;
        playerInputMap = playerInputActions.FindActionMap("Player");
        rb = this.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        movement = playerInputMap.FindAction("Movement");
        movement.Enable();
        playerInputMap.FindAction("Jump").started += DoJump;
        playerInputMap.Enable();
    }

    private void DoJump(InputAction.CallbackContext context)
    {
        //if (IsGrounded())
        //{
            forceDirection += Vector3.up * jumpForce;
        //}
    }

    private void OnDisable()
    {
       movement.Disable();
       playerInputMap.FindAction("Jump").started -= DoJump;
        playerInputMap.Disable();
    }

    private void FixedUpdate()
    {
        //read input values
        forceDirection += movement.ReadValue<Vector2>().x *GameObject.Find("Main Camera").transform.right;
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

        MoveLookAt();
    }

    private void MoveLookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0;

        if (movement.ReadValue<Vector2>().magnitude > 0.1f && direction.magnitude > 0.1f)
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            rb.angularVelocity = Vector3.zero;
    }

    //Gets forward direction of camera relative to the horizontal
    private Vector3 GetCameraForward(Camera camera)
    {
        Vector3 forward = camera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    //Gets right direction of camera relative to the horizontal
    private Vector3 GetCameraRight(Camera camera)
    {
        Vector3 right = camera.transform.right;
        right.y = 0;
        return right.normalized;
    }
    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
            return true;
        else
            return false;
    }
}
