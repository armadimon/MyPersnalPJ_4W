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
}