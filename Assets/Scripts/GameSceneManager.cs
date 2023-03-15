using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSceneManager
{
    public static void LoadMenu() => SceneManager.LoadScene("Menu");
    public static void LoadMachine() => SceneManager.LoadScene("Machine");
}