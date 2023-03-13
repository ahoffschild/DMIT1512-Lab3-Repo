using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerBehavior : MonoBehaviour
{
    [SerializeField] SpringJoint2D springJoint;
    [SerializeField] int pullSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PullPlunger(float pullValue)
    {
        springJoint.distance = pullValue * 2.2f;
        springJoint.attachedRigidbody.AddForce(Vector2.down * pullValue * pullSpeed);
    }

}
