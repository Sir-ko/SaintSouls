using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject music;
    private EasyMusic easyMusic;
    void Start()
    {
        easyMusic = FindObjectOfType<EasyMusic>();
       if(PlayerPrefs.GetInt("Difficulty") == 1)
        {
            music.SetActive(true);
            easyMusic.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
