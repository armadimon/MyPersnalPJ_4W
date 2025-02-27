using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardSystem : MonoBehaviour, IScoreSystem
{
    private Dictionary<string, int> scores = new Dictionary<string, int>();
    public Text stackScoreText;

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

    public int GetScore(string key)
    {
        return scores.ContainsKey(key) ? scores[key] : 0;
    }

    public void InitializeScore()
    {
        
    }

    public void SetScore(string key, int amount)
    {
            scores[key] = amount;
    }

    public Dictionary<string, int> GetAllScores()
    {
        return scores;
    }

    public void SetScoreToLeaderboard()
    {
        if (scores.ContainsKey("StackMaxScore"))
        {
            stackScoreText.text = scores["StackMaxScore"].ToString();
        }
    }
}
