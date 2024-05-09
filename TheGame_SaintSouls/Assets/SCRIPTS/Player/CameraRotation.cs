using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;

    public float minAngle = -15;
    public float maxAngle = 60;

    public float RotationSpeed = 50f;
    void Update()
    {
        //все не так!!! как проснусь поменяю. короче, нужно один раз сохранить все в плеерпрефс, потом в передать значение в слайдер такой же в меню паузы, потом уже оттуда считывать постоянно, должно тратить не такую уйму ресурсов
        RotationSpeed = PlayerPrefs.GetFloat("MouseSensetivity", 50);
        Mathf.Lerp(70f, 20f, RotationSpeed);
        var newAngleY = transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X");
        var newAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");

        if (newAngleX > 180)
            newAngleX -= 360;

        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);

        transform.localEulerAngles = new Vector3(0, newAngleY, 0);
        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
