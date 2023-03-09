using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameTester : MonoBehaviour
{
    [SerializeField] InputAction IncreaseScore;
    [SerializeField] InputAction DecreaseScore;
    [SerializeField] InputAction ResetScore;
    [SerializeField] InputAction SaveScore;
    [SerializeField] InputAction LoadScore;
    [SerializeField] InputAction TrySaveHighScore;

    GameState currentGameState;

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameObject.FindGameObjectWithTag("GameStateManager").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IncreaseScore.WasPressedThisFrame())
        {
            IncreaseCurrentScore();
        }
        if (DecreaseScore.WasPressedThisFrame())
        {

        }
    }

    void IncreaseCurrentScore()
    {
        currentGameState.score += 1;
    }

    void DecreaseCurrentScore()
    {
        currentGameState.score -= 1;
    }
}
