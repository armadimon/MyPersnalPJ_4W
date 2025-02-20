using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackScoreSystem : MonoBehaviour, IScoreSystem
{
    private Dictionary<string, int> scores = new Dictionary<string, int>();

    public void AddScore(string key, int amount)
    {
        if (scores.ContainsKey(key))
        {
            scores[key] += amount;
        }
        else
        {
            scores[key] = amount;
        }
    }

    public void SetScore(string key, int amount)
    {
        scores[key] = amount;
    }
    
    public int GetScore(string key)
    {
        return scores.ContainsKey(key) ? scores[key] : 0;
    }

    public void InitializeScore()
    {
        if (scores.ContainsKey("StackScore"))
        {
            Debug.Log("Stack Score Initialized");
            scores["StackScore"] = 0;
            
            Debug.Log(this.GetScore("StackScore").ToString());
        }
        Debug.Log("Stack Score DeInitialized");
    }

    public Dictionary<string, int> GetAllScores()
    {
        return scores;
    }
}
