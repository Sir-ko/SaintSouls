using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Save", 1));
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
