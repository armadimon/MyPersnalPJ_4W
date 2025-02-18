using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform weaponPivot;
    
    protected Vector2 movementDirection = Vector2.zero;
    
    public Vector2 MovementDirection {get {return movementDirection;}}
    
    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection {get {return lookDirection;}}
    
    private Vector2 knockBack = Vector2.zero;
    private float knockBackDuration = 0.0f;

    protected AnimationHandler animationHandler;
    protected StatHandler statHandler;

    protected bool isAttacking;
    private float timeSinceLastAttack = float.MaxValue;
    
    protected void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }
    protected virtual void Start()
    {
        
    }

    protected void FixedUpdate()
    {
        Movement(movementDirection);
        if (knockBackDuration > 0.0f)
        {
            knockBackDuration -= Time.fixedDeltaTime;
        }
    }

    protected virtual void HandleAction()
    {
        
    }

    private void Movement(Vector2 direction)
    {
        direction = direction * statHandler.Speed;
        
        _rigidbody2D.velocity = direction;
        animationHandler.Move(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;
        
        _spriteRenderer.flipX = isLeft;

        if (weaponPivot != null)
        {
            weaponPivot.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
    }

    public void ApplyKnockBack(Transform other, float power, float duration)
    {
        knockBackDuration = duration;
        knockBack = (other.position - transform.position).normalized * power;
        
        
    }
}
