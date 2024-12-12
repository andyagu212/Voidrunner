using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //Declarations

    //Game
    [SerializeField] private List<GameObject> lifes;
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
        
    }

    //Disable lifes in UI
    public void ChangeLife(int life)
    {
        lifes[life].SetActive(false);
    }

    //Disable lifes in UI
    public void GameOver()
    {
        gameOver.SetActive(true);
    }
}
