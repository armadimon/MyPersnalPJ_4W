using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGameTest : MonoBehaviour, IInteractableObject
{
    public GameObject button;

    public void Interact()
    {
        Debug.Log("Interact");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            button.SetActive(true);
            button.GetComponentInChildren<TMP_Text>().text = "SampleScene";
            Debug.Log("자동으로 인터랙트 활성화!");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            button.SetActive(false);
                Debug.Log("플레이어가 영역을 떠나 인터랙트 비활성화");
        }
    }
    
    // public void EnterMiniGame(string sceneName)
    // {
    //     SceneManager.LoadScene(sceneName);
    // }
}
