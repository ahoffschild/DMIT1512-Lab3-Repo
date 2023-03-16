using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIBehavior : MonoBehaviour
{
    [SerializeField] ScoreDisplayType scoreDisplayType;
    GameSaveManager gameSaveManager;
    GameState gameState;
    TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
		gameSaveManager = FindObjectOfType<GameSaveManager>();
		if (scoreDisplayType == ScoreDisplayType.Local)
        {
            textMesh.text = $"Your Local Score is:\n{gameSaveManager.playerScore}";
        }
        else
        {
            gameSaveManager.LoadFromDisk();
			textMesh.text = $"The High Score is:\n{gameSaveManager.highScore}";
		}
    }
}

public enum ScoreDisplayType
{
    Local,
    Load
}