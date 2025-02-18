using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb2d;
    
    public float flapForce = 6f;

    public float forwardSpeed = 3f;

    public bool isDead = false;
    private float deathCooldown = 0f;
    
    private bool _isFlap = false;
    public bool godMode = false;
    
    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        _animator = GetComponentInChildren<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();

        if (_animator == null)
        {
            Debug.LogError("No Animator attached");
        }
        
        if (_rb2d == null)
            Debug.LogError("No rigidbody attached");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0f)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            // GetMouseButtonDown(x) 의 매개변수 x는 스마트폰의 터치 인풋도 수행해준다.
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                _isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        
        Vector3 velocity = _rb2d.velocity;
        velocity.x = forwardSpeed;

        if (_isFlap)
        {
            velocity.y += flapForce;
            _isFlap = false;
        }
        
        _rb2d.velocity = velocity;

        float angle = Mathf.Clamp(_rb2d.velocity.y * 10f, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (isDead) return;
        
        isDead = true;
        deathCooldown = 1f;
        
        _animator.SetInteger("IsDie", 1);
        gameManager.GameOver();
    }
}
