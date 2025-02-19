using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StackBtn : MonoBehaviour
{
    public void RestartGame()
    {
        StackGameManager.Instance.StartGame();    
    }
    
    
    public void StartGame()
    {
        StackGameManager.Instance.uiManager.DeactivePanel();
    }

    public void ReturnMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
