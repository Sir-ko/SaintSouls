using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{
    public GameObject Player;
    public Transform BaseToTpTo;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnLevelWasLoaded()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (GameData.Instance.PlayersLastLevel <= currentScene)
        {
            GameData.Instance.PlayersLastLevel = SceneManager.GetActiveScene().buildIndex;
        }
        else
        {
            Player.SetActive(false);
            Player.transform.position = BaseToTpTo.position;
            Player.SetActive(true);
        }
    }
}
