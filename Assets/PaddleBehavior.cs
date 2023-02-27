using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] HingeJoint2D hinge;
    [SerializeField] float motorSpeed;
    JointMotor2D motor;
    // Start is called before the first frame update
    void Start()
    {
        motor = hinge.motor;
        motor.motorSpeed = motorSpeed;
        hinge.motor = motor;
    }

    // Update is called once per frame
    void Update()
    {
        Flip(Keyboard.current.spaceKey.isPressed);
    }

    public void Flip(bool isPressed)
    {
        if (isPressed)
        {
            hinge.useMotor = true;
        }
        else
        {
            hinge.useMotor = false;
        }
    }
}
