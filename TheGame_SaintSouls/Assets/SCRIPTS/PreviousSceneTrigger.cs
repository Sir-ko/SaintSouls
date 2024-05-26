using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousSceneTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.GetInt("PreviousLevel", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
