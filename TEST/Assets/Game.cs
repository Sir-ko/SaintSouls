using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    public int score = 0;
    public int scorePerClick = 1;
    public int scoreToUpdate = 10;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textToUpdate;
    void Start()
    {
        score = 0;
        text.SetText("0");
    }
    public void ButtonClick()
    {
        score += scorePerClick;
        text.SetText(score.ToString());
    }

    public void Upgrade() 
    {
        if (score >= scoreToUpdate)
        {
            score -= scoreToUpdate;
            scorePerClick++;
            scoreToUpdate *= 2;
            textToUpdate.SetText($"cost: {scoreToUpdate}");
            text.SetText(score.ToString());
        }
    }
}
