using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string mainSceneName = "MainScene";  // 메인 씬의 이름
    public string miniGameSceneName = "SampleScene";  // 미니 게임 씬의 이름

    // 메인 씬을 계속 유지하면서 미니 게임 씬으로 전환
    public void StartMiniGame()
    {
        // 미니 게임 씬으로 전환
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(miniGameSceneName, LoadSceneMode.Additive);  // Additive로 씬을 추가
    }

    // 미니 게임 씬 종료 후, 메인 씬으로 돌아오기
    public void EndMiniGame()
    {
        // 미니 게임 씬 종료
        DontDestroyOnLoad(this);
        SceneManager.UnloadSceneAsync(miniGameSceneName);  // 미니 게임 씬 비활성화
        
        // 원래 씬으로 돌아감
        SceneManager.LoadScene(mainSceneName);
    }
}