using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] HingeJoint2D hinge;
    // Start is called before the first frame update
    void Start()
    {
        hinge.useMotor = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Flip(Keyboard.current.spaceKey.isPressed);
    }

    public void Flip(bool isPressed)
    {
        hinge.useMotor = isPressed;
    }
}
