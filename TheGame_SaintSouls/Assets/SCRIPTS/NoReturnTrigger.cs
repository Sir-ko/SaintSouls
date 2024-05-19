using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoReturnTrigger : MonoBehaviour
{
    public DialogeController controller;

    private void OnTriggerEnter(Collider other)
    {
        controller.NoReturnText();
    }
}
