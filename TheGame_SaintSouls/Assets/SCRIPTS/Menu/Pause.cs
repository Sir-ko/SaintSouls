using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel;
    [SerializeField] GameObject _settingsPanel;
    public GameObject player;

    public Slider MouseSensetivity;
    public Slider OverallVolume;

    public CameraRotation playerCamera;

    public AudioSource Music;
    private AudioSource enemySource;
    private AudioSource playerSource;

    public float volume = 0.5f;

    bool _isPaused = false;
    

    private void Start()
    {
        _isPaused = false;
        _pausePanel.SetActive(false);
        enemySource = FindObjectOfType<EnemyAI>().gameObject.GetComponent<AudioSource>();
        playerSource = player.GetComponent<AudioSource>();
        MouseSensetivity.value = PlayerPrefs.GetFloat("MouseSensetivity", 0.5f);
        OverallVolume.value = PlayerPrefs.GetFloat("Volume", 0.7f);
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
        _settingsPanel.SetActive(false);
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
        PlayerPrefs.SetFloat("Volume", OverallVolume.value);
        Music.volume = OverallVolume.value;
        enemySource.volume = OverallVolume.value;
        playerSource.volume = OverallVolume.value;
        playerCamera.Change_nowSpeed();
        PlayerPrefs.Save();
    }
}
