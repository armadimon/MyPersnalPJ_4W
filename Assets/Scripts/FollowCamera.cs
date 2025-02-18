using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float minX, maxX, minY, maxY;
    
    void Start()
    {
        if (target == null)
            return;
    }

    void Update()
    {
            float clampedX = Mathf.Clamp(target.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(target.position.y, minY, maxY);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
