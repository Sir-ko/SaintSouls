using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenuScreen;
    public GameObject ExitScreen;
    public GameObject LoadPointScreen;
    public void Start()
    {
        MainMenuScreen.SetActive(true);
        ExitScreen.SetActive(false);
        LoadPointScreen.SetActive(false);
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
}
