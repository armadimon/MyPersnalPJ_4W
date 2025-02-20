using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private MainUIManager mainUI;
    public string LastScene { get; private set; } = "";
    public bool sceneLoaded = false;
    public static GameManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        mainUI = FindObjectOfType<MainUIManager>();
    }
    
    public void LoadScene(string sceneName)
    {
        LastScene = sceneName;
        SceneManager.LoadScene(sceneName);
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (LastScene == "StackScene" && scene.name == "MainScene")
            sceneLoaded = true;
    }
}
