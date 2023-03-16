using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class GameSaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    protected GameState gameState;
    public int playerScore;
    public int highScore;
    string dataPath;

    private void Awake()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "Pinball_HighScore.txt");
		gameState = GameObject.FindObjectOfType<GameState>();
		GameObject[] objs = GameObject.FindGameObjectsWithTag("SaveManager");
		if (objs.Length > 1)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
        playerScore = 0;
        highScore = 0;
        if (!File.Exists(dataPath))
        {
            SaveToDisk();
        }
	}

	public void LoadFromDisk()
    {
        if (File.Exists(dataPath))
        {
            using (StreamReader streamReader = File.OpenText(dataPath))
            {
                string jsonString = streamReader.ReadToEnd();

                playerScore = gameState.score;
                JsonUtility.FromJsonOverwrite(jsonString, gameState);
                if (gameState == null)
                {
                    highScore = 0;
                }
                else
                {
                    highScore = gameState.score;
                }
            }
        }
    }

    public void SaveToDisk()
    {
        string jsonString = JsonUtility.ToJson(gameState);
        using (StreamWriter sw = File.CreateText(dataPath))
        {
            sw.Write(jsonString);
        }
    }
}
