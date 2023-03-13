using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperBehavior : MonoBehaviour
{
    [SerializeField] BumperState state;
    Color originalColor;
    [SerializeField] Color newColor;
    [SerializeField] float animationTimer;
    float internalTimer;
    Vector3 baseScale;
    float baseRadius;
    new CircleCollider2D collider;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<CircleCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        state = BumperState.Idle;
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        internalTimer = 0;
        baseScale = transform.localScale;
        baseRadius = collider.radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == BumperState.Idle && transform.localScale != baseScale)
        {
            transform.localScale = baseScale;
        }
        if (state == BumperState.Struck)
        {
            Animate1();
        }
        if (state == BumperState.Return)
        {
            Animate2();
        }
    }

    void Animate1()
    {
        if (internalTimer >= animationTimer)
        {
            state = BumperState.Return;
        }
        else
        {
            gameObject.transform.localScale = baseScale + new Vector3(0.2f * (internalTimer / animationTimer), 0.2f * (internalTimer / animationTimer), 0);
            Debug.Log(baseScale + new Vector3(0.2f * (internalTimer / animationTimer), 0.2f * (internalTimer / animationTimer), 0));
            collider.radius = baseRadius - 0.1f * (internalTimer / animationTimer);
            internalTimer++;
        }
    }

    void Animate2()
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
            collider.radius = baseRadius - 0.1f * (internalTimer / animationTimer);
            internalTimer--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        state = BumperState.Struck;
        spriteRenderer.color = newColor;
    }
}

public enum BumperState
{
    Idle,
    Struck,
    Return
}
