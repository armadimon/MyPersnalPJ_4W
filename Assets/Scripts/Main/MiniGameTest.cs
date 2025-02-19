using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGameTest : MonoBehaviour, IInteractableObject
{
    public GameObject Menu;

    public void Interact()
    {
        Debug.Log("Interact");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Menu.SetActive(true);
            Menu.GetComponentInChildren<TMP_Text>().text = PlayerPrefs.GetInt("Game1Score").ToString();
            Debug.Log("인터랙트 활성화");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Menu != null)
                 Menu.SetActive(false);
            Debug.Log("인터랙트 비활성화");
        }
    }
    
}
