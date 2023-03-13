using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperBehavior : MonoBehaviour
{
    [SerializeField] BumperState state;
    Color originalColor;
    [SerializeField] Color newColor;
    [SerializeField] int animationTimer;
    int internalTimer;
    Vector3 baseScale;
    float baseRadius;
    new CircleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<CircleCollider2D>();
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
        if (internalTimer > animationTimer)
        {
            state = BumperState.Return;
        }
        else
        {
            transform.localScale = baseScale + new Vector3(0.2f * (internalTimer / animationTimer), 0.2f * (internalTimer / animationTimer));
            collider.radius = baseRadius - 0.1f * (internalTimer / animationTimer);
            internalTimer++;
        }
    }

    void Animate2()
    {
        if (internalTimer <= 0)
        {
            state = BumperState.Idle;
            internalTimer = 0;
        }
        else
        {
            transform.localScale = baseScale - new Vector3(0.2f * (internalTimer / animationTimer), 0.2f * (internalTimer / animationTimer));
            collider.radius = baseRadius + 0.1f * (internalTimer / animationTimer);
            internalTimer--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        state = BumperState.Struck;
        Debug.Log("Help");
    }
}

public enum BumperState
{
    Idle,
    Struck,
    Return
}
