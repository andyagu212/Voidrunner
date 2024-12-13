using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //Declarations

    //Game
    [SerializeField] private List<GameObject> lifes;
    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private GameObject levelMenu;
    [SerializeField] private GameObject gameOver;

    //Create instance
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Pause
        if (Input.GetKeyDown(KeyCode.F))
        {
            levelMenu.SetActive(true);
            GameManager.Instance.PauseGame();
        }
    }

    //Destroy this
    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    //Pause
    private void Pause()
    {
        GameManager.Instance.PauseGame();
    }

    //Disable lifes in UI
    public void ChangeLife(int life)
    {
        lifes[life].SetActive(false);
    }

    //IncreaseScore
    public void IncreaseScore()
    {
        score += 100;
        scoreText.text = "Score: " + score.ToString();
    }

    //Disable lifes in UI
    public void GameOver()
    {
        gameOver.SetActive(true);
        gameOverScoreText.text = "Score: " + score.ToString();
    }
}
