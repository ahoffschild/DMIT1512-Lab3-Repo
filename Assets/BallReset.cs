using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallReset : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            SetBallPosition(Camera.main.ScreenToWorldPoint(Mouse.current.position.value));
        }
    }
    public void SetBallPosition(Vector2 pos)
    {
        rb.transform.position = pos;
        rb.velocity = Vector2.zero;
        
    }
}
