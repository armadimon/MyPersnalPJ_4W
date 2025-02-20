using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isLanded = false;
    public bool IsLanded { get { return isLanded; } set { isLanded = value; } }
    
    private bool isFalling = false;
    public bool IsFalling { get { return isFalling; } set { isFalling = value; } }
    

    public void SetIsLanded(bool input)
    {
        isLanded = input;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isLanded)
            return;
        isLanded = true;

        StackGameManager.Instance.BlockLanded();
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isLanded && !isFalling)
        {
            StackGameManager.Instance.GameOver();
        }
    }
}
