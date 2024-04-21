using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;

    public float minAngle = -15;
    public float maxAngle = 60;

    public float RotationSpeed = 1f;
    void Update()
    {
        var newAngleY = transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X");
        var newAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");

        if (newAngleX > 180)
            newAngleX -= 360;

        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);

        transform.localEulerAngles = new Vector3(0, newAngleY, 0);
        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
