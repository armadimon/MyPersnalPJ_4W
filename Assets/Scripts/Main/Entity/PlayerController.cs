using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera _camera;
    private LayerMask _targetLayer;
    /*
    private GameManager _gameManager;

    public void Init(GameManager gameManager)
    {
        _gameManager = gameManager;
        _camera = Camera.main;
    }
    */

    protected override void Start()
    {
        base.Start();
        _camera = Camera.main;
    }
    
    protected override void HandleAction()
    {
        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;
        
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = _camera.ScreenToWorldPoint(mousePos); //마우스 해상도 좌표를 월드 좌표로
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
        RaycastHit2D hit =  Physics2D.Raycast(transform.position, LookDirection, 1, _targetLayer);
        
        if (hit.collider != null)
        {
            // 특정 레이어에 충돌한 경우
            Debug.Log("레이가 " + hit.collider.gameObject.name + "에 충돌!");

            // 충돌한 오브젝트의 메서드 실행
            IInteractableObject obj = hit.collider.gameObject.GetComponent<IInteractableObject>();
            if (obj != null)
            {
                // Enemy 클래스의 메서드 호출
                obj.Interact();
            }
        }
    }
}
