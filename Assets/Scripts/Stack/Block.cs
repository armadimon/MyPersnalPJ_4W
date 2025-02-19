using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isLanded = false;
    

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
}
