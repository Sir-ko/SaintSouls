using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireingTorch : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip lightend;
    public AudioClip unligted;

    public GameObject LightPrefab;
    public GameObject FirePrefab;

    public float distanceToLight;
    public bool shouldWork = false;
    public bool hasWaited;
    public float timeToNewActivation2 = 3f;
    public float timeHasPastSince = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasWaited = true;
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
            if (hasWaited == false)
            {
                timeHasPastSince += Time.deltaTime;
                if (timeHasPastSince > timeToNewActivation2)
                {
                    hasWaited = true;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.F))
                {
                    LightPrefab.SetActive(!LightPrefab.active);
                    FirePrefab.SetActive(LightPrefab.active);
                    if(LightPrefab.activeSelf == true)
                    {
                        audioSource.PlayOneShot(lightend);
                    }
                    else
                    {
                        audioSource.PlayOneShot(unligted);
                    }
                    timeHasPastSince = 0f;
                    hasWaited = false;
                }
            }
        }
    }
}
