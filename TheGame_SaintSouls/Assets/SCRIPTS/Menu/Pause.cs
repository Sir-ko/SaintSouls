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
    private AudioSource easyMusic;

    public float volume = 0.5f;

    bool _isPaused = false;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _isPaused = false;
        _pausePanel.SetActive(false);
        if(SceneManager.GetActiveScene().buildIndex != 4) 
            enemySource = FindObjectOfType<EnemyAI>().gameObject.GetComponent<AudioSource>();
        playerSource = player.GetComponent<AudioSource>(); 
        var a = FindObjectOfType<EasyMusic>();
        if(a != null)
            easyMusic = a.GetComponent<AudioSource>();
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
        AudioListener.pause = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void ResumeGame()
    {
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

    public void ToggleHeadbob()
    {
        bool a = player.GetComponent<HeadBobController>().enable;
        player.GetComponent<HeadBobController>().enable = !a; 
    }
    public void ChangePreferences()
    {
        PlayerPrefs.SetFloat("MouseSensetivity", MouseSensetivity.value);
        PlayerPrefs.SetFloat("Volume", OverallVolume.value);
        Music.volume = OverallVolume.value;
        if (SceneManager.GetActiveScene().buildIndex != 4)
            enemySource.volume = OverallVolume.value;
        playerSource.volume = OverallVolume.value;
        if(easyMusic != null) easyMusic.volume = OverallVolume.value;
        playerCamera.Change_nowSpeed();
        PlayerPrefs.Save();
    }
}
