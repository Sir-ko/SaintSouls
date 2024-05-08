using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToFourCorners : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 p1 = GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0, 0, GetComponent<Camera>().nearClipPlane));
        Vector3 p2 = GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0, 1, GetComponent<Camera>().nearClipPlane));
        Vector3 p3 = GetComponent<Camera>().ViewportToWorldPoint(new Vector3(1, 0, GetComponent<Camera>().nearClipPlane));
        Vector3 p4 = GetComponent<Camera>().ViewportToWorldPoint(new Vector3(1, 1, GetComponent<Camera>().nearClipPlane));
    }

}
