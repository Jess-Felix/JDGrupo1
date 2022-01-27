using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeigth;

    [SerializeField] private float rotationSpeed;

    //References
    private CharacterController controller;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y=-2f;
        }
        
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        
        moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
              
                Walk();
            
            } else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                
                Run();
            } else if (moveDirection == Vector3.zero)
            {
               
                Idle();
            }
            
            moveDirection *= moveSpeed;
            
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        
        controller.Move(moveDirection * Time.deltaTime);
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.333f, 0.05f, Time.deltaTime);
    }
    
    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 0.666f,0.05f, Time.deltaTime);

    }
    
    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.05f, Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeigth * -2 * gravity);
    }
}
