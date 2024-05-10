using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel;
    public Slider MouseSensetivity;
    public Slider OverallVolume;
    public CameraRotation playerCamera;

    public float volume = 0.5f;

    bool _isPaused = false;
    

    private void Start()
    {
        _isPaused = false;
        _pausePanel.SetActive(false);
        MouseSensetivity.value = PlayerPrefs.GetFloat("MouseSensetivity", 0.5f);
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
    public void ChangePreferences()
    {
        PlayerPrefs.SetFloat("MouseSensetivity", MouseSensetivity.value);
        PlayerPrefs.SetFloat("Volume", volume);
        playerCamera.ChangeSpeed();
        PlayerPrefs.Save();
    }
}
