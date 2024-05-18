using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;

    public float minAhgle;
    public float maxAngle;

    public float RotationSpeed;
    
           
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X"), 0);

        var newAhgleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
        if (newAhgleX > 180)
            newAhgleX -= 360;
        
        newAhgleX = Mathf.Clamp(newAhgleX, minAhgle, maxAngle);

        CameraAxisTransform.localEulerAngles = new Vector3(newAhgleX, 0 , 0);

    }
}
