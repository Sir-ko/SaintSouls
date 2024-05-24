using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;
    public Transform Player;

    public float minAngle = -15;
    public float maxAngle = 60;

    public float Rotation_nowSpeed = 0.5f;

    private void Start()
    {
        Change_nowSpeed();
    }
    void Update()
    {
        var newAngleY = Player.transform.localEulerAngles.y + Time.deltaTime * Rotation_nowSpeed * Input.GetAxis("Mouse X");
        var newAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * Rotation_nowSpeed * Input.GetAxis("Mouse Y");

        if (newAngleX > 180)
            newAngleX -= 360;

        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);

        Player.transform.localEulerAngles = new Vector3(0, newAngleY, 0);
        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }

    public void Change_nowSpeed()
    {
        Rotation_nowSpeed = PlayerPrefs.GetFloat("MouseSensetivity", 0.5f);
        Mathf.Lerp(0.7f, 0.2f, Rotation_nowSpeed);
        Rotation_nowSpeed *= 100;
    }
}
