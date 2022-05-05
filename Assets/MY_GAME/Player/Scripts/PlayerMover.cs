using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerMask layerMask;
    
    private Rigidbody playerRigidbody;
    private RaycastHit hit;
    private Animator playerAnimator;
    private float speedX, speedZ;
    private float playerHeight = 1.5f;
    private bool isJump;
    private Vector3 playerVelocity;
    private Vector3 offsetRay;
    private Quaternion currentPlayerRotation;
    
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        offsetRay = new Vector3(0, 1.45f, 0);
    }
    
    private void Update()
    {
        AnimationRunner();
        CalculateMoveSpeed();
        CheckIsJump();
        Jump();
    }

    private void FixedUpdate()
    {
        LookAtRotation();
        Move();
    }

    private void LookAtRotation()
    {
        if (speedX == 0 && speedZ == 0)
        {
            transform.rotation = currentPlayerRotation;
            return;
        }
        
        float angle  = Mathf.Atan2(speedX, speedZ) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        currentPlayerRotation = transform.rotation;
    }
    private void CalculateMoveSpeed()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            speedX = Input.GetAxis("Horizontal") * speed;
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            speedZ = Input.GetAxis("Vertical") * speed;
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            speedX = 0;
        }
        
        if (Input.GetAxis("Vertical") == 0)
        {
            speedZ = 0;
        }
        
        playerVelocity.x = speedX * Time.deltaTime;
        playerVelocity.z = speedZ * Time.deltaTime;
        playerVelocity.y = playerRigidbody.velocity.y;
    }

    private void Move()
    {
        playerRigidbody.velocity = playerVelocity;
    }

    private void CheckIsJump()
    {
        Physics.Raycast(transform.position + offsetRay, Vector3.down,out hit, playerHeight, layerMask);

        isJump = hit.collider == null;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
        {
            playerRigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    private void AnimationRunner()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            playerAnimator.SetBool("isMove", true);
        }
        else
        {
            playerAnimator.SetBool("isMove", false);
        }

        playerAnimator.SetBool("isJump", isJump != false);
    }
}
