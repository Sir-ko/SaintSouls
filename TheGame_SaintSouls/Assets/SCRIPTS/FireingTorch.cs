using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireingTorch : MonoBehaviour { 

    public GameObject LightPrefab;
    public GameObject FirePrefab;

    public float distanceToLight;
    public bool shouldWork = false;

    private void Start()
    {
        if(shouldWork == false) {
            LightPrefab.SetActive(false);
            FirePrefab.SetActive(false);
        }
        else
        {
            LightPrefab.SetActive(true);
            FirePrefab.SetActive(true);
        }
    }

    void Update()
    {
        
        if (Vector3.Distance(Camera.main.transform.position, transform.position) <= distanceToLight)
        {
            if (Input.GetKey(KeyCode.F))
            {
                LightPrefab.SetActive(!LightPrefab.active);
                FirePrefab.SetActive(!LightPrefab.active);
                Debug.Log("done");
            }
        }
    }
}
