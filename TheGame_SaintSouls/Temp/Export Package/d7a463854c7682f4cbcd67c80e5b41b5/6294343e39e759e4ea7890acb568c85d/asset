using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;
    
    private Vector3 _moveVector;
    private float _fallVelocity = 0;    
    private CharacterController _characterController;
        
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
     
    void Update()
    {     
        MovementPlayerUpdate();
        JumpPlayerUpdate();        
    }
    
    void FixedUpdate()
    {
        MovementPlayerFixedUpdate();
        FallJumpPlayerFixedUpdate();
        StopFallPlayerFixedUpdate();
    }

    private void MovementPlayerUpdate()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
    }

    private void JumpPlayerUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }

    private void MovementPlayerFixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);
    }

    private void FallJumpPlayerFixedUpdate()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
    }

    private void StopFallPlayerFixedUpdate()
    {
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
