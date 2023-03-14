using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIBehavior : MonoBehaviour
{
    [SerializeField] UIType type;
    TextMeshProUGUI textMeshPro;
    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
		gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
	}

    // Update is called once per frame
    void Update()
    {
        if (type == UIType.Score)
        {
            textMeshPro.text = $"SCORE: {gameState.score}";
        }
        if (type == UIType.Lives)
        {
			textMeshPro.text = $"LIVES: 0";
		}
    }
}

public enum UIType
{
    Score,
    Lives
}