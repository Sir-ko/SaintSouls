using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    public bool enable = true;

    public float aplitude = 0.015f;
    public float frequency = 10.0f;
    public float frequencyAcceleration = 3f;

    public Transform camera;
    public Transform cameraHolder;

    public float toggleSpeed = 3.0f;
    public Vector3 startPos;
    public PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        startPos = camera.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(!enable) return;
        
        CheckMotion();
        ResetPosition();
        camera.LookAt(FocusTarget());
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * aplitude;
        pos.x += Mathf.Cos(Time.time * frequency) * aplitude * 2;
        return pos;
    }
    
    private void CheckMotion()
    {
        if (playerMovement.isMoving() != false) return;
        frequency = 10;
        if(playerMovement.ReturnSpeed() == playerMovement.acseleration)
        {
            frequency += frequencyAcceleration;
        }
        PlayMotion(FootStepMotion());
    }

    private void ResetPosition()
    {
        if(camera.localPosition == startPos) return;
        camera.localPosition = Vector3.Lerp(camera.localPosition, startPos, 1 * Time.deltaTime);
    }
    private void PlayMotion(Vector3 motion)
    {
        camera.localPosition += motion;
    }
    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + cameraHolder.localPosition.y, transform.position.z);
        pos += cameraHolder.forward * 15.0f;
        return pos;
    }
}
