using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitBehavior : MonoBehaviour
{
    [SerializeField] Transform ballSpawnPoint;
    [SerializeField] GateBehavior gateBehavior;
    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
		gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(WaitToRespawn(collision));
        gateBehavior.GateOpen();
        gameState.ballsLeft--;
    }

    IEnumerator WaitToRespawn(Collider2D collider)
    {
        yield return new WaitForSeconds(2);
        collider.attachedRigidbody.transform.position = ballSpawnPoint.position;
        collider.attachedRigidbody.velocity = Vector2.zero;
    }
}
