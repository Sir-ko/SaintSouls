using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void LoadNextLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var newSceneIndex = currentSceneIndex + 1;
        PlayerPrefs.SetInt("currentLevel", newSceneIndex);
        SceneManager.LoadScene(newSceneIndex);
    }
    public void LoadCurrentLevel()
    {
        var currentLevel = PlayerPrefs.GetInt("currentLevel");
        SceneManager.LoadScene(currentLevel);
    }
    public void LoadPreviousLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("currentLevel", currentSceneIndex - 1);
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void NewGame()
    {
        PlayerPrefs.SetInt("currentLevel", 1);
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)) //для отладки
        {
            LoadNextLevel();
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            LoadPreviousLevel();
        }
    }
}
