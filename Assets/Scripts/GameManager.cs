using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int world { get; private set;}
    public int stage { get; private set;}
    public int lives { get; private set;}
    public int coins { get; private set;}


    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }

        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        
        NewGame();
    }

    public void NewGame()
    {
        lives = 3;
        coins = 0;

        LoadLevel(1, 1);
    }

    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives = lives - 1;

        if (lives > 0)
        {
            LoadLevel(1, 1);
        }

        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        lives = 3;
        coins = 0;
        SceneManager.LoadScene("0-0");
    }

    public void AddCoin()
    {
        coins = coins + 1;

        if (coins == 100)
        {
            AddLife();
            coins = 0;
        }
    }

    public void AddLife()
    {
        lives = lives + 1;
    }
}
