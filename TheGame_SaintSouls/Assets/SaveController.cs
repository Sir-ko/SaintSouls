using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public GameObject player;
    public float timeToSaveInSec = 1f;
    private void Start()
    {
        StartCoroutine("SaveGame");
        Debug.Log("StartedCoroutine");
    }

    IEnumerable SaveGame()
    {
        while (true) // не работает
        {
            PlayerPrefs.SetFloat("player_x", player.transform.position.x);
            PlayerPrefs.SetFloat("player_y", player.transform.position.y);
            PlayerPrefs.SetFloat("player_z", player.transform.position.z);
            PlayerPrefs.SetInt("Save", SceneManager.GetActiveScene().buildIndex);
            //сюда же если что ключи сохранять там всякую фигню
            PlayerPrefs.Save();
            Debug.Log("Made a save");
            yield return new WaitForSecondsRealtime(2f);
        }
    }
}
