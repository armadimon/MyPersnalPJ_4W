using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public LeaderBoardSystem leaderBoardSystem;
    public GameObject stackResultPanel;
    
    void Start()
    {
        ScoreManager.Instance.SetScoreSystem(leaderBoardSystem);
        ScoreManager.Instance.LoadScores("Stack");
        leaderBoardSystem.SetScoreToLeaderboard();
        if (GameManager.Instance.sceneLoaded)
        {
            ShowGameResult(GameManager.Instance.LastScene);
        }
    }
    public void ShowGameResult(string lastScene)
    {
        ScoreManager.Instance.LoadScores("Stack");
        
        if (lastScene == "StackScene")
        {
            Transform curScore = stackResultPanel.transform.Find("CurScore");
            
            if (curScore != null)
            {
                Text curScoreText = curScore.GetComponent<Text>();
                if (curScoreText != null)
                {
                    Debug.Log(ScoreManager.Instance.GetScore("StackScore").ToString());
                    curScoreText.text = ScoreManager.Instance.GetScore("StackScore").ToString();
                }
            }
            else
            {
                Debug.LogError("not found stack score");
            }
            
            Transform maxScore = stackResultPanel.transform.Find("MaxScore");

            if (maxScore != null)
            {
                Text maxScoreText = maxScore.GetComponent<Text>();
                if (maxScoreText != null)
                {
                    Debug.Log(ScoreManager.Instance.GetScore("StackMaxScore").ToString());
                    maxScoreText.text = ScoreManager.Instance.GetScore("StackMaxScore").ToString();
                }
            }
            else
            {
                Debug.LogError("not found stack score");
            }
        }
        stackResultPanel.SetActive(true);
        GameManager.Instance.sceneLoaded = false;
    }
}
