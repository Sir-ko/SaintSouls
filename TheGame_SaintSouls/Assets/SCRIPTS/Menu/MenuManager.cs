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

    public float volume = 0.5f;
    public int difficulty = 0; //0 = normal; 1 = easy

    public void Start()
    {
        PlayerPrefs.SetFloat("MouseSensetivity", 0.5f);
        MouseSensetivity.value = 0.5f;
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
        PlayerPrefs.SetInt("Save", 1);
        Invoke("LoadFirstLevel", 3.2f); //надо еще все сейв файлы обнулить бf
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("FirstLevel");
    }
    public void LoadFromLastSave() 
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Save", 1));
        /*PlayerPrefs.GetFloat("player_x", 15.52f);
        PlayerPrefs.GetFloat("player_y", 0f);
        PlayerPrefs.GetFloat("player_z", 0.469f);
        */
    }
    public void FromLastSave()
    {
        AnimatorCamera.SetTrigger("PlayCamera");
        AnimatorDoor.SetTrigger("PlayDoor");
        Invoke("LoadFromLastSave", 3.2f);
    }

    public void ChangePreferences()
    {
        PlayerPrefs.SetFloat("MouseSensetivity", MouseSensetivity.value);
        PlayerPrefs.SetFloat("Volume", volume);
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
