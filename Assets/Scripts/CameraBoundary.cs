using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    private FollowCamera followCamera;

    void Start()
    {
        // 카메라 오브젝트에서 FollowCamera 컴포넌트 찾기
        followCamera = Camera.main.GetComponent<FollowCamera>();
        Debug.Log(followCamera);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            Debug.Log("벽에 부딪힘! 카메라 멈춤.");
            followCamera.isActive = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            Debug.Log("벽에서 벗어남! 카메라 다시 움직임.");
            followCamera.isActive = true;
        }
    }
}