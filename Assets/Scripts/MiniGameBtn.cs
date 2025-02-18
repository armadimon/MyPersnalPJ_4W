using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniGameBtn : MonoBehaviour
{
    public void EnterMiniGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
