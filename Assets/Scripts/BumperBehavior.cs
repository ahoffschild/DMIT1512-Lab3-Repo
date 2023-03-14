using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperBehavior : MonoBehaviour
{
    [SerializeField] BumperType type;
    BumperState state;
    Color originalColor;
    [SerializeField] Color newColor;
    [SerializeField] float animationTimer;
    float internalTimer;
    Vector3 baseScale;
    CircleCollider2D circleCollider;
    PolygonCollider2D polygonCollider;
    SpriteRenderer spriteRenderer;
    [SerializeField] int points;
    GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        switch (type)
        {
            case (BumperType.Circle):
                circleCollider = gameObject.GetComponent<CircleCollider2D>();
				break;
            case (BumperType.Polygon):
                polygonCollider = gameObject.GetComponent<PolygonCollider2D>();
                break;
        }
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        state = BumperState.Idle;
        originalColor = spriteRenderer.color;
        internalTimer = 0;
        baseScale = transform.localScale;
		gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
	}

    // Update is called once per frame
    void Update()
    {
		if (state == BumperState.Idle && transform.localScale != baseScale)
		{
			transform.localScale = baseScale;
		}
		switch (type)
        {
            case (BumperType.Circle):
				if (state == BumperState.Struck)
				{
					AnimateCircle1();
				}
				if (state == BumperState.Return)
				{
					AnimateCircle2();
				}
				break;
            case (BumperType.Polygon):
				if (state == BumperState.Struck)
				{
					AnimatePolygon1();
				}
				if (state == BumperState.Return)
				{
					AnimatePolygon2();
				}
				break;
        }
    }

    void AnimateCircle1()
    {
        if (internalTimer >= animationTimer)
        {
            state = BumperState.Return;
        }
        else
        {
            transform.localScale = baseScale + new Vector3(0.2f * (internalTimer / animationTimer), 0.2f * (internalTimer / animationTimer), 0);
            internalTimer++;
        }
    }

    void AnimateCircle2()
    {
        if (internalTimer <= 0)
        {
            state = BumperState.Idle;
            spriteRenderer.color = originalColor;
            internalTimer = 0;
        }
        else
        {
            transform.localScale = baseScale + new Vector3(0.2f * (internalTimer / animationTimer), 0.2f * (internalTimer / animationTimer), 0);
            internalTimer--;
        }
    }
	void AnimatePolygon1()
	{
		if (internalTimer >= animationTimer)
		{
			state = BumperState.Return;
		}
		else
		{
			transform.localScale = baseScale + new Vector3(0.2f * (internalTimer / animationTimer), 0.2f * (internalTimer / animationTimer), 0);
			internalTimer++;
		}
	}
	void AnimatePolygon2()
	{
		if (internalTimer <= 0)
		{
			state = BumperState.Idle;
			spriteRenderer.color = originalColor;
			internalTimer = 0;
		}
		else
		{
			transform.localScale = baseScale + new Vector3(0.2f * (internalTimer / animationTimer), 0.2f * (internalTimer / animationTimer), 0);
			internalTimer--;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
        state = BumperState.Struck;
        spriteRenderer.color = newColor;
        gameState.score += points;
    }
}

public enum BumperState
{
    Idle,
    Struck,
    Return
}

public enum BumperType
{
    Circle,
    Polygon,
    Capsule
}
