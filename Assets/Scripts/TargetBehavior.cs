using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
	TargetState state;
	Color originalColor;
	[SerializeField] Color hitColor;
	[SerializeField] Color fadedColor;
	[SerializeField] float animationTimer;
	float internalTimer;
	Vector3 baseScale;
	new BoxCollider2D collider;
	SpriteRenderer spriteRenderer;
	[SerializeField] int points;
	GameState gameState;
	// Start is called before the first frame update
	void Start()
    {
		collider = gameObject.GetComponent<BoxCollider2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		state = TargetState.Idle;
		originalColor = spriteRenderer.color;
		gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
		internalTimer = 0;
		baseScale = transform.localScale;
	}

    // Update is called once per frame
    void Update()
    {
		if (state == TargetState.Idle || state == TargetState.Inactive && transform.localScale != baseScale)
		{
			transform.localScale = baseScale;
		}
		if (state == TargetState.Struck)
		{
			Animate1();
		}
		if (state == TargetState.Return)
		{
			Animate2();
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (state == TargetState.Idle)
		{
			state = TargetState.Struck;
			spriteRenderer.color = hitColor;
			gameState.score += points;
			gameState.targetCount--;
		}
	}

	void Animate1()
	{
		if (internalTimer >= animationTimer)
		{
			state = TargetState.Return;
		}
		else
		{
			transform.localScale = baseScale + new Vector3(0.2f * (internalTimer / animationTimer), 0.2f * (internalTimer / animationTimer), 0);
			internalTimer++;
		}
	}

	void Animate2()
	{
		if (internalTimer >= animationTimer)
		{
			spriteRenderer.color = fadedColor;
			state = TargetState.Inactive;
			collider.enabled = false;
			internalTimer = 0;
		}
		else
		{
			transform.localScale = baseScale + new Vector3(0.2f * (internalTimer / animationTimer), 0.2f * (internalTimer / animationTimer), 0);
			internalTimer--;
		}
	}

	public void RespawnTarget()
	{
		spriteRenderer.color = originalColor;
		state = TargetState.Idle;
		collider.enabled = true;
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
}

public enum TargetState
{
	Idle,
	Struck,
	Return,
	Inactive
}
