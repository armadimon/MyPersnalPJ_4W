using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    // Start is called before the first frame update    
    void Start()
    {
        if (restartText == null)
            Debug.LogError("restartText is null");
        if (scoreText == null)
            Debug.LogError("restartText is null");
        
        restartText.gameObject.SetActive(false);
    }
    
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }
}
