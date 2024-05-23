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
        if(SceneManager.GetActiveScene().buildIndex != 0)
            SceneManager.sceneLoaded += OnLoadCallback;
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("WasLastSceneMenu", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        if (PlayerPrefs.GetInt("WasLastSceneMenu") == 0)
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            Player = FindObjectOfType<PlayerMovement>().gameObject;
            BaseToTpTo = FindObjectOfType<BaseToTpToScript>().transform;
            if (PlayerPrefs.GetInt("PreviousLevel", 1) <= currentScene)
            {
                PlayerPrefs.SetInt("PreviousLevel", currentScene);
                PlayerPrefs.Save();
            }
            else
            {
                Player.active = false;
                Player.transform.position = BaseToTpTo.position;
                Player.active = true;
                Debug.Log("madeTP");
            }
        }
    }
}
