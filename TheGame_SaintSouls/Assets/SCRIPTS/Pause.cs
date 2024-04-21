using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel;

    bool _isPaused = false;

    private void Start()
    {
        _isPaused = false;
        _pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        _isPaused = false;
    }
    public void LoadMainMenu()
    {
        _isPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public bool isPaused()
    {
        return _isPaused;
    }
}
