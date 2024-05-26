using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneMusic : MonoBehaviour
{
    public Light light;

    public AudioSource Music;
    public AudioClip scream;
    void Start()
    {
        Music = GetComponent<AudioSource>();
        Music.Play();
    }

    public void Scream()
    {
        StartCoroutine(darkness());
        Music.PlayOneShot(scream);

    }
    public IEnumerator darkness()
    {
        float time = 0f;
        while(time < 7f)
        {
            time += Time.deltaTime;
            light.intensity -= 0.5f * Time.deltaTime;
            yield return null;
        }
        light.enabled = false;
    }
}
