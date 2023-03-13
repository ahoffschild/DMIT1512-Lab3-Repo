using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperBehavior : MonoBehaviour
{
    BumperState state;
    Color originalColor;
    [SerializeField] Color newColor;
    [SerializeField] int animationTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum BumperState
{
    Idle,
    Struck,
    Return
}
