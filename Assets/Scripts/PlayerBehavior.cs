using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] PaddleBehavior leftPaddle;
    [SerializeField] PaddleBehavior rightPaddle;
    [SerializeField] PlungerBehavior plunger;
	[SerializeField] GameState gameState;

	[SerializeField] InputAction useLeft;
    [SerializeField] InputAction useRight;
    [SerializeField] InputAction usePlunger;
    [SerializeField] InputAction goToMenu;

    private void OnEnable()
    {
        useLeft.Enable();
        useRight.Enable();
        usePlunger.Enable();
		goToMenu.Enable();
    }

    private void OnDisable()
    {
        useLeft.Disable();
        useRight.Disable();
        usePlunger.Disable();
		goToMenu.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftPaddle.Flip(useLeft.IsPressed());
        rightPaddle.Flip(useRight.IsPressed());
        plunger.PullPlunger(usePlunger.ReadValue<float>());
        gameState.ReturnToMenu(goToMenu.IsPressed());
    }
}
