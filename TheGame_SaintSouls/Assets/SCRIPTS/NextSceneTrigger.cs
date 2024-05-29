using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{
    public GameObject Player;
    public Transform BaseToTpTo;

    private void Start()
    {
        Player = FindObjectOfType<PlayerMovement>().gameObject;
        BaseToTpTo = FindObjectOfType<BaseToTpToScript>().transform;
        SceneManager.sceneLoaded += OnLoadCallback;
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("WasLastSceneMenu", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        if (PlayerPrefs.GetInt("ShouldTP") == 1)
        {
            Player = FindObjectOfType<PlayerMovement>().gameObject;
            BaseToTpTo = FindObjectOfType<BaseToTpToScript>().transform;
            Player.SetActive(false);
            Player.transform.position = BaseToTpTo.position;
            Player.SetActive(true);
            PlayerPrefs.SetInt("ShouldTP", 0);
        }
    }
}
