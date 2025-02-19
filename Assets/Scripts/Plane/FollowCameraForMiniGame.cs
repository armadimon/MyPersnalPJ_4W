using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraForMiniGame : MonoBehaviour
{
    public Transform target;
    private float offSetX;
    
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            return;
        
        offSetX = transform.position.x - target.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = target.position.x + offSetX;
        transform.position = pos;
    }
}
