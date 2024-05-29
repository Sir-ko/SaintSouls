using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private EasyMusic easyMusic;
    void Awake()
    {
       easyMusic = FindObjectOfType<EasyMusic>();
       if(PlayerPrefs.GetInt("Difficulty") == 1)
        {
            if (easyMusic != null)
                easyMusic.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
       else
        {
            if(easyMusic != null)
                easyMusic.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}
