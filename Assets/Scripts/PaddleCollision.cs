using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PaddleCollision : MonoBehaviour
{
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
}
