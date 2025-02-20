using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreSystem
{
    void AddScore( string score_key, int amount);
    int GetScore(string score_key);
    void SetScore(string score_key, int amount);
    Dictionary<string, int> GetAllScores();
    void InitializeScore();
}
