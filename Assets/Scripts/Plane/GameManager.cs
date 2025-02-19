using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SceneController sceneController;
    static GameManager gameManager;
    UIManager uiManager;

    public UIManager UIManager
    {
        get { return uiManager; }
    }

    public static GameManager Instance
    {
        get { return gameManager; }
    }
    private int currentScore = 0;
    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        PlayerPrefs.SetInt("Game1Score", currentScore);
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.UnloadSceneAsync("SampleScene");  // 미니 게임 씬 비활성화
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score : " + currentScore);
        uiManager.UpdateScore(currentScore);
    }
}
