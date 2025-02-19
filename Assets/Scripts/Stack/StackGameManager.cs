using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StackGameManager : MonoBehaviour
{
    private static StackGameManager _instance;
    public static StackGameManager Instance { get { return _instance; } }
    [SerializeField] private Transform[] blockPrefabs; // 여러 블록 프리팹 저장
    [SerializeField] private Transform blockHolder;
    
    public Transform currentBlock = null;
    private Rigidbody2D currentRigidbody = null;
    
    private Vector2 blockStartPos = new Vector2(0, 4f);
    private float fallSpeed = 1.0f;
    private float fastFallMultiplier = 5f;
    private float moveSpeed = 0.2f;
    private float lastMoveTime;
    private float moveCooldown = 0.1f;
    private float rotationAngle = 90f;
    
    public StackUIManager uiManager;
    
    private int score = 0;
    
    void Awake()
    {
        if (_instance == null)
            _instance = this;
    }
    void Start()
    {
        SpawnNewBlock();
    }

    public void SpawnNewBlock()
    {
        // 랜덤한 블록 선택
        int randomIndex = Random.Range(0, blockPrefabs.Length);
        currentBlock = Instantiate(blockPrefabs[randomIndex], blockHolder);

        currentBlock.position = blockStartPos;
        currentRigidbody = currentBlock.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!currentBlock) return;

        HandleMovement();
        HandleRotation();
        HandleFall();
    }

    private void HandleMovement()
    {
        if (Time.time - lastMoveTime < moveCooldown) return;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentBlock.position += Vector3.left * moveSpeed;
            lastMoveTime = Time.time;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            currentBlock.position += Vector3.right * moveSpeed;
            lastMoveTime = Time.time;
        }
    }

    private void HandleRotation()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentBlock.Rotate(Vector3.forward, -rotationAngle);
        }
    }

    private void HandleFall()
    {
        float speed = fallSpeed;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed *= fastFallMultiplier;
        }

        currentBlock.position += Vector3.down * speed * Time.deltaTime;
    }
    
    public void BlockLanded()
    {
        score++;
        uiManager.UpdateScore(score, TextType.Score);
        currentRigidbody.gravityScale = 1f;
        currentBlock = null;
        Invoke(nameof(SpawnNewBlock), 0.2f);
    }

    public void GameOver()
    {
        int maxScore = PlayerPrefs.GetInt("StackMaxScore", 0);
        if (maxScore < score)
        {
            maxScore = score;
            PlayerPrefs.SetInt("StackMaxScore", score);
        }
        
        uiManager.UpdateScore(maxScore, TextType.MaxScore);
        uiManager.ActiveEndPannel();
        Time.timeScale = 0f;
    }
    


    public void StartGame()
    {
        currentBlock = null;
        currentRigidbody = null;
        // DontDestroyOnLoad(this);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
