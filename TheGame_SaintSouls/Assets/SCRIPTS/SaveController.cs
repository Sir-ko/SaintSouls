using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SaveController : MonoBehaviour
{
    public TextMeshProUGUI DialogeText;
    public GameObject Player;
    public float timeToSaveInSec = 1f;
    private void Awake()
    {
        if(PlayerPrefs.GetInt("WasLastSceneMenu") == 1 && PlayerPrefs.GetInt("NewGame") == 0)
        {
            Player.SetActive(false);
            Player.transform.position = new UnityEngine.Vector3(PlayerPrefs.GetFloat("player_x", 15.51f), PlayerPrefs.GetFloat("player_y", 0f),
                                                                   PlayerPrefs.GetFloat("player_z", 0.469f));
            Player.SetActive(true);
            DialogeText.enabled = false;
        }
        StartCoroutine(SaveGame());
        Debug.Log("StartedCoroutine");
    }

    IEnumerator SaveGame()
    {
        while (true)
        {     
            PlayerPrefs.SetFloat("player_x", Player.transform.position.x);
            PlayerPrefs.SetFloat("player_y", Player.transform.position.y);
            PlayerPrefs.SetFloat("player_z", Player.transform.position.z);
            PlayerPrefs.SetInt("Save", SceneManager.GetActiveScene().buildIndex);
            //сюда же если что ключи сохранять там всякую фигню
            PlayerPrefs.Save();
            Debug.Log("Made a save");
            yield return new WaitForSeconds(timeToSaveInSec);
        }
    }
}
