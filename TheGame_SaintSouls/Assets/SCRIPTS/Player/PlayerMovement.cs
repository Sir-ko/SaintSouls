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
    public AudioSource heartRateAudio;
    public GameObject Player;
    public GameObject PauseMenu;
    public GameObject SettingsMenu;

    public float _nowSpeed;
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
        {
            _nowSpeed = acseleration;
            moveSound.pitch = 1.3f;
        }
        else
        {
            _nowSpeed = speed;
            moveSound.pitch = 1.0f;
        }
        _moveVector.Normalize();
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
        if ((Mathf.Abs(Input.GetAxis("Horizontal")) > 0.35f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.35f) && Time.timeScale != 0f)
        {
            if (moveSound.isPlaying) return;
            moveSound.Play();
        }
        else
        {
            moveSound.Stop();
        }
    }

    public bool isMoving()
    {
        return (_moveVector != Vector3.zero) && (Time.timeScale != 0) ? true : false;
    }
    public float ReturnSpeed()
    {
        return _nowSpeed;
    }
    public void StartHeartRate()
    {
        if(heartRateAudio.isPlaying) return;
        heartRateAudio.Play();
        Debug.Log("HeartRate Started");
    }
    public void StopHeartRate()
    {
        heartRateAudio.Stop();
    }
}

