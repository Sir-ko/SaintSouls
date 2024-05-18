using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float acseleration;
    public AudioSource moveSound;

    private CharacterController _characterController;
    private Vector3 _moveVector;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMoveVector();
        SoundStep();
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) 
            speed = acseleration;

        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);
    }

    private void GetMoveVector()
    {
        _moveVector = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
    }
    

    void SoundStep()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.35f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.35f)
        {
            if (moveSound.isPlaying) return;
            moveSound.Play();
        }
        else
        {
            moveSound.Stop();
        }
    }
}

