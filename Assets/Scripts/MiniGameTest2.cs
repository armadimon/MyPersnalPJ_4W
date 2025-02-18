using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameTest2 : MonoBehaviour, IInteractableObject
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
            button.GetComponentInChildren<TMP_Text>().text = "Minigame2";
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
}
