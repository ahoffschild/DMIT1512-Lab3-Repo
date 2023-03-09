using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class GameSaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    protected GameState gameState;

    public void LoadFromDisk()
    {
        string dataPath = Path.Combine(Application.persistentDataPath, "Pinball_HighScore.txt");

        if(File.Exists(dataPath))
        {
            using (StreamReader streamReader = File.OpenText(dataPath))
            {
                string jsonString = streamReader.ReadToEnd();
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
