using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
	public void StartGame()
	{
		GameSceneManager.LoadMachine();
		FindObjectOfType<GameState>().StartMachine();
	}
}
