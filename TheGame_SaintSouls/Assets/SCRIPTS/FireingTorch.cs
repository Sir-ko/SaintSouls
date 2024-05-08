using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireingTorch : MonoBehaviour { 

    public GameObject LightenedTorchPrefab;

    public float distanceToLight;

    void Update()
    {

        if (Vector3.Distance(Camera.main.transform.position, transform.position) <= distanceToLight)
        {
            if (Input.GetKey(KeyCode.F))
            {
                Instantiate(LightenedTorchPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
                Debug.Log("done");
            }
        }
    }
}
