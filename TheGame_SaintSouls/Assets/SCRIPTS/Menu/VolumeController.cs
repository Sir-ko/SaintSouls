using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = PlayerPrefs.GetFloat("Volume", 0.7f);
    }
    public void ChangeVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
