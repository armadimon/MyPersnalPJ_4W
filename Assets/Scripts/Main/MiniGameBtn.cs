using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniGameBtn : MonoBehaviour
{
    public GameObject miniGameMenu;
    public void EnterMiniGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitMiniGame()
    {
        miniGameMenu.SetActive(false);
    }
}
