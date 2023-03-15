using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameManagerState gameState;
    public int score = 0;
    public int targetCount = 4;
    [SerializeField] int ballsCount;
    public int ballsLeft;
    [SerializeField] int targetRespawnTimer;
    [SerializeField] int targetFullClear;
    int internalTimer;
    TargetBehavior[] targets = new TargetBehavior[4];
    GameSaveManager saveManager;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        int i = 0;
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Target"))
        {
            targets[i] = gameObject.GetComponent<TargetBehavior>();
            i++;
        }
        ballsLeft = ballsCount;
        gameState = GameManagerState.Active;
        saveManager = FindObjectOfType<GameSaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetCount == 0)
        {
            RespawnTargets();
        }
        if (ballsLeft == 0 && gameState == GameManagerState.Active)
        {
            GameObject.Find("Ball").SetActive(false);
            gameState = GameManagerState.Inactive;
        }
    }

    void RespawnTargets()
    {
        if (internalTimer == 0)
        {
            score += targetFullClear;
        }
        if (internalTimer >= targetRespawnTimer)
        {
            foreach (TargetBehavior targetBehavior in targets)
            {
                targetBehavior.RespawnTarget();
            }
			internalTimer = 0;
            targetCount = 4;
		}
        else
        {
            internalTimer++;
        }
    }

    public void ReturnToMenu(bool check)
    {
        if (check && gameState == GameManagerState.Inactive)
        {
            saveManager.LoadFromDisk();
            if (saveManager.highScore < score)
            {
                saveManager.SaveToDisk();
            }
            GameSceneManager.LoadMenu();
		}
	}

    public string HighscoreString()
    {
        string output;
        output = $"SCORE = {score}";
        return output;
    }
}

public enum GameManagerState
{
    Active,
    Inactive
}
