using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogeController : MonoBehaviour
{
    public TextMeshProUGUI DialogeText;
    public GameObject NoGoTrigger;

    public bool hasIntroduced = true;
    public float secBeforeDeletingInstructions = 15f;

    private void Start()
    {
        StartCoroutine(NewGameText());
        DialogeText.enabled = false;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            DialogeText.text = "That hurt... where am I? There was no such place on maps. I hope nobody is here...";
        }
    }

    public IEnumerator NewGameText()
    {
        if(hasIntroduced == true)
        {
            hasIntroduced = false; 
        }
        yield return WaitForSecondsRealtime(secBeforeDeletingInstructions);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ScaryTrigger") Debug.Log("done");
    }
}
