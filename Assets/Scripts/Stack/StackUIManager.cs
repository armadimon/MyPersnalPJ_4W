using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum TextType
{
    MaxScore,
    Score
}
public class StackUIManager : MonoBehaviour
{
        
    public Text scoreText;
    public Text maxScoreText;
    // public Text countdownText;
    public GameObject endPanel;
    public GameObject fadeoutPanel;
    // public Animator anim;
    // public EventSystem eventSystem;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void DeactivePanel()
    {
        Time.timeScale = 1f;
        StartCountdown();
    }
    private void StartCountdown()
    {
        fadeoutPanel.SetActive(false);
        // int countdown = 3;
        //
        // while (countdown > 0)
        // {
        //     countdownText.text = countdown.ToString();
        //     yield return new WaitForSeconds(1f); 
        //     countdown--;
        // }
        // countdownText.text = "Start!";
        // yield return new WaitForSeconds(1.0f);
        // countdownText.gameObject.SetActive(false);
    }
    public void UpdateScore(int score, TextType type)
    {
        if (type == TextType.MaxScore)
            maxScoreText.text = score.ToString();
        else if (type == TextType.Score)
            scoreText.text = score.ToString();
    }

    public void ActiveEndPannel()
    {
        Time.timeScale = 0f;
        endPanel.SetActive(true);
    }
}
