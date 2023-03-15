using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickoutBehavior : MonoBehaviour
{
    KickoutState kickoutState;
    GameObject ball;
    float oldGravity;
    [SerializeField] int KickoutPullDuration;
    [SerializeField] int KickoutFallDuration;
	[SerializeField] int KickoutInsideDuration;
    [SerializeField] int KickoutCooldown;
    [SerializeField] int score;
    int internalTimer;
    float pullValue;
    Vector3 freezePosition;
    Vector3 freezeVelocity;
    SpriteRenderer spriteRenderer;
    GameState gameState;
	// Start is called before the first frame update
	void Start()
    {
        internalTimer = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
		gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
	}

    // Update is called once per frame
    void Update()
    {
        switch (kickoutState)
        {
            case (KickoutState.Pulling):
                Pulling();
                break;
            case (KickoutState.Falling):
                Falling();
                break;
            case (KickoutState.Inside):
                Inside();
                break;
            case (KickoutState.Cooldown):
                Cooldown();
                break;
        }
	}

    void Pulling()
    {
        if (internalTimer > KickoutPullDuration)
        {
            kickoutState = KickoutState.Falling;
            ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			internalTimer = 0;
        }
        else
        {
            pullValue = (float)internalTimer / (float)KickoutPullDuration;
            ball.transform.position = freezePosition * (1f - pullValue) + gameObject.transform.position * pullValue;
            internalTimer++;
        }
	}

    void Falling()
    {
		if (internalTimer > KickoutFallDuration)
		{
			kickoutState = KickoutState.Inside;
			internalTimer = 0;
		}
		else
		{
            pullValue = (float)internalTimer / (float)KickoutFallDuration;
			ball.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f - pullValue);
			internalTimer++;
		}
	}

    void Inside()
    {
		if (internalTimer > KickoutInsideDuration)
		{
			kickoutState = KickoutState.Cooldown;
            ball.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
			ball.GetComponent<Rigidbody2D>().velocity = freezeVelocity;
			ball.GetComponent<Rigidbody2D>().gravityScale = oldGravity;
            spriteRenderer.color *= 0.8f;
			internalTimer = 0;
		}
		else
		{
            if (internalTimer % 100 == 0)
            {
                gameState.score += score;
            }
			internalTimer++;
		}
	}

    void Cooldown()
    {
        if (internalTimer > KickoutCooldown)
        {
            kickoutState = KickoutState.Idle;
            spriteRenderer.color *= 1.25f;
            internalTimer = 0;
        }
        else
        {
            internalTimer++;
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (kickoutState == KickoutState.Idle)
        {
            kickoutState = KickoutState.Pulling;
            ball = collision.gameObject;
            oldGravity = collision.attachedRigidbody.gravityScale;
            collision.attachedRigidbody.gravityScale = 0;
            freezePosition = collision.transform.position;
            freezeVelocity = collision.attachedRigidbody.velocity;
        }
	}
}

public enum KickoutState
{
    Idle,
    Pulling,
    Falling,
    Inside,
    Cooldown
}