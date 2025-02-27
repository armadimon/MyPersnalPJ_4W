using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    private IScoreSystem scoreSystem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetScoreSystem(IScoreSystem newSystem)
    {
        scoreSystem = newSystem;
    }

    public void AddScore(string key, int amount)
    {
        scoreSystem?.AddScore(key, amount);
    }

    public int GetScore(string key)
    {
        return scoreSystem?.GetScore(key) ?? 0;
    }

    public void SetScore(string key, int score)
    {
        scoreSystem?.SetScore(key, score);
    }
    
    public void InitializeScore()
    {
        
        scoreSystem?.InitializeScore();
    }

    public void SaveScores(string gameName)
    {
        var allScores = scoreSystem?.GetAllScores();
        if (allScores != null)
        {
            string json = JsonConvert.SerializeObject(allScores);
            PlayerPrefs.SetString(gameName, json);
            PlayerPrefs.Save();
        }
    }

    public void LoadScores(string gameName)
    {
        if (PlayerPrefs.HasKey(gameName))
        {
            string json = PlayerPrefs.GetString(gameName);
            var loadedScores = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
            foreach (var kvp in loadedScores)
            {
                scoreSystem?.SetScore(kvp.Key, kvp.Value);
            }
        }
    }
}