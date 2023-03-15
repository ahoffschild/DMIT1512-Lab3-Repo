using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class GameSaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    protected GameState gameState;
    public int highScore;
    string dataPath;

    private void Awake()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "Pinball_HighScore.txt");
    }

	private void Start()
	{
		gameState = GameObject.FindObjectOfType<GameState>();
	}

	public void LoadFromDisk()
    {
        if (File.Exists(dataPath))
        {
            using (StreamReader streamReader = File.OpenText(dataPath))
            {
                string jsonString = streamReader.ReadToEnd();

                JsonUtility.FromJsonOverwrite(jsonString, highScore);
            }
        }
    }

    public void SaveToDisk()
    {
        string jsonString = JsonUtility.ToJson(gameState.score);
        using (StreamWriter sw = File.CreateText(dataPath))
        {
            sw.Write(jsonString);
        }
    }
}
