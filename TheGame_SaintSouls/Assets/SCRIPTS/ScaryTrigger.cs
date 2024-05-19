using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryTrigger : MonoBehaviour
{
    public DialogeController controller;
    public CameraRotationEndScene CameraRotationEndScene;

    private void OnTriggerEnter(Collider other)
    {
        //controller.EndGame();
        CameraRotationEndScene.EndScene();
    }
}
