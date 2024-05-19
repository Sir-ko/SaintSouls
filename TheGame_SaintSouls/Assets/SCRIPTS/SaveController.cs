using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public GameObject player;
    public float timeToSaveInSec = 1f;

    private Coroutine saveGame;
    private void Awake()
    {
        saveGame = StartCoroutine(SaveGame());
        Debug.Log("StartedCoroutine");
    }

    IEnumerator SaveGame()
    {
        while (true)
        {
            PlayerPrefs.SetInt("Save", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetFloat("player_x", player.transform.position.x);
            PlayerPrefs.SetFloat("player_y", player.transform.position.y);
            PlayerPrefs.SetFloat("player_z", player.transform.position.z);
            PlayerPrefs.SetInt("Save", SceneManager.GetActiveScene().buildIndex);
            //сюда же если что ключи сохранять там всякую фигню
            PlayerPrefs.Save();
            Debug.Log("Made a save");
            yield return new WaitForSeconds(timeToSaveInSec);
        }
    }
}
