using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float gravity = 9.8f;
    public float _fallVelocity = 0f;
    public float speed;
    public float acseleration;
    public AudioSource moveSound;
    public GameObject Player;

    public float _nowSpeed;
    private CharacterController _characterController;
    private Vector3 _moveVector;
    
    void Awake()
    {
        Player.transform.position = new Vector3(PlayerPrefs.GetFloat("player_x", 15.51f), PlayerPrefs.GetFloat("player_y", 0f),
                                                               PlayerPrefs.GetFloat("player_z", 0.469f));
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
        Jump();
        if (_characterController.isGrounded) _fallVelocity = 0;
    }

    private void Jump()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) 
            _nowSpeed = acseleration;
        else 
            _nowSpeed = speed;
        _characterController.Move(_moveVector * _nowSpeed * Time.fixedDeltaTime);
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

