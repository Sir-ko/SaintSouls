using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenuScreen;
    public GameObject ExitScreen;
    public GameObject LoadPointScreen;
    public GameObject SettingsScreen;

    public Animator AnimatorCamera;
    public Animator AnimatorDoor;

    public Slider MouseSensetivity;
    public Slider OverallVolume;

    public Toggle EasyMode;

    public AudioSource Music;

    public int difficulty = 0; //0 = normal; 1 = easy

    public void Start()
    {
        PlayerPrefs.SetInt("ShouldTP", 0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerPrefs.SetInt("JustBeenDead", 0);
        PlayerPrefs.SetInt("WasLastSceneMenu", 1);
        MouseSensetivity.value = 0.5f;
        OverallVolume.value = PlayerPrefs.GetFloat("Volume", 0.7f);
        Music.volume = OverallVolume.value;
        Music.Play();
    }
    public void Awake()
    {
        MainMenuScreen.SetActive(true);
        ExitScreen.SetActive(false);
        LoadPointScreen.SetActive(false);
        SettingsScreen.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        AnimatorCamera.SetTrigger("PlayCamera");
        AnimatorDoor.SetTrigger("PlayDoor");
        float a = MouseSensetivity.value;
        float b = OverallVolume.value;
        int diff = difficulty;
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Difficulty", diff);
        PlayerPrefs.SetInt("ShouldTP", 0);
        PlayerPrefs.SetFloat("MouseSensetivity", a);
        PlayerPrefs.SetInt("JustBeenDead", 0);
        PlayerPrefs.SetInt("WasLastSceneMenu", 1);
        PlayerPrefs.SetFloat("Volume", b);
        PlayerPrefs.SetInt("Save", 1);
        PlayerPrefs.SetInt("NewGame", 1);
        PlayerPrefs.Save();
        Invoke("LoadFirstLevel", 3.2f); //надо еще все сейв файлы обнулить бf
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("FirstLevel");
    }
    public void LoadFromLastSave() 
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Save", 1));
    }
    public void FromLastSave()
    {
        AnimatorCamera.SetTrigger("PlayCamera");
        AnimatorDoor.SetTrigger("PlayDoor");
        PlayerPrefs.SetInt("NewGame", 0);
        Invoke("LoadFromLastSave", 3.2f);
    }

    public void ChangePreferences()
    {
        difficulty = EasyMode.isOn ? 1 : 0;
        PlayerPrefs.SetFloat("MouseSensetivity", MouseSensetivity.value);
        PlayerPrefs.SetFloat("Volume", OverallVolume.value);
        Music.volume = OverallVolume.value;
        PlayerPrefs.SetInt("Difficulty", difficulty);
        PlayerPrefs.Save();
    }
    public void NormalModeChosen()
    {
        difficulty = 0;
    }
    public void EasyModeChosen()
    {
        difficulty = 1;
    }
}
