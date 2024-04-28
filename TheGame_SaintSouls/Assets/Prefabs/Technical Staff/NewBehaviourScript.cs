using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Camera Camera;
    void Start()
    {
        var quadHeight = Camera.main.orthographicSize * 2.0;
        var quadWidth = quadHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3((float)quadWidth, (float)quadHeight, 1f);
    }

}
