using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private Animator playerAnimator;
    
    [SerializeField] private float moveSpeed = 45f;
    [SerializeField] private float jumpSpeed = 5f;

    private bool _isGrounded = true;

    private bool _isLookingRight = true;
    // Update is called once per frame

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("Speed_f",0.0f);
    }

    private void Update()
    {
        MovementInput();
    }

    private void MovementInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (_isLookingRight)
            {
                RotateWay();
                _isLookingRight = false;
            }
            else
            {
                Move(Vector3.left);   
            }
                 
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnimator.SetFloat("Speed_f",0.0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (_isLookingRight)
            {
                Move(Vector3.right);
            }
            else
            {
               RotateWay();
                _isLookingRight = true;
            }
            
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnimator.SetFloat("Speed_f",0.0f);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
       
    }

    private void RotateWay()
    {
        _rigidbody.transform.Rotate(0,180,0);
    }
    private void Move(Vector3 direction)
    {

        _rigidbody.AddForce(direction * moveSpeed , ForceMode.Force);
        playerAnimator.SetFloat("Speed_f",0.5f);
        
    }
    
    private void Jump()
    {
      
        if (!_isGrounded) return;
        playerAnimator.SetTrigger("Jump_trig");
        _rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
  
       
        // playerAnimator.SetBool("Jump_b",true);
        // playerAnimator.SetBool("Jump_b", false);

    }

    
    private void OnCollisionExit(Collision other)
    {
       
        _isGrounded = false;
        // playerAnimator.SetBool("Jump_b",true);
    }

    private void OnCollisionEnter(Collision other)
    {  
        _isGrounded = true;
        // playerAnimator.SetBool("Jump_b",false);
    }
}
