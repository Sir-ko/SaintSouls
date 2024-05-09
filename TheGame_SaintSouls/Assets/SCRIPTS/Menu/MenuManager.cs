using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenuScreen;
    public GameObject ExitScreen;
    public GameObject LoadPointScreen;
    public GameObject SettingsScreen;

    public Slider MouseSensetivity;
    public Slider OverallVolume;

    public int difficulty = 0; //0 = normal; 1 = easy

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
        SceneManager.LoadScene("FirstLevel"); //надо еще все сейв файлы обнулить б
    }
    public void FromLastSave()
    {

    }

    public void ChangePreferences()
    {
        PlayerPrefs.SetFloat("MouseSensetivity", MouseSensetivity.value);
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
