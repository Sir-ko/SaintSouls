using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogeController : MonoBehaviour
{
    public TextMeshProUGUI DialogeText;
    public TextMeshProUGUI InstructionsText;
    public GameObject NoGoTrigger;
    public Animator CameraAnimator;
    public GameObject Player;
    public GameObject pointOfStart;
    public GameObject PauseMenu;
    public GameObject SettingsMenu;

    public bool hasIntroduced = true;
    public float secBeforeDeletingInstructions = 15f;

    private void Start()
    {
        
        DialogeText.enabled = true;
        InstructionsText.enabled = true;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            DialogeText.text = "Oh, a long fall it was. That hurt... where am I? There was no such place on maps. I hope nobody is here...";
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            DialogeText.text = "What a strange place. Have anybody been here before?";
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3) 
        {
            DialogeText.text = "I can almost hear wildlife... I guess, it's gonna be over soon. I hope.";
        }
        InstructionsText.text = "WASD - move\r\nF - light torch\r\nESC - menu\r\nescape.";
        StartCoroutine(NewSceneText());
    }

    private void Update()
    {
        if(PauseMenu.active == true || SettingsMenu.active == true)
        {
            DialogeText.enabled = false;
            InstructionsText.enabled = false;
        }
    }

    public IEnumerator NewSceneText()
    {
        Debug.Log("Started");
        yield return new WaitForSecondsRealtime(secBeforeDeletingInstructions);
        DialogeText.enabled = false;
        InstructionsText.enabled = false;
    }
    public IEnumerator NoReturnScene()
    {
        yield return new WaitForSecondsRealtime(2f);
        DialogeText.enabled = false;
    }

    public void NoReturnText()
    {
        DialogeText.enabled = true;
        DialogeText.text = "There is no way I'm going back...";
        StartCoroutine(NoReturnScene());
    }
}
