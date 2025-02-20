using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameTest2 : MonoBehaviour, IInteractableObject
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
