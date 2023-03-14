using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int score = 0;
    public int targetCount = 4;
    [SerializeField] int ballsCount;
    public int ballsLeft;
    [SerializeField] int targetRespawnTimer;
    [SerializeField] int targetFullClear;
    int internalTimer;
    TargetBehavior[] targets = new TargetBehavior[4];
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        int i = 0;
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Target"))
        {
            targets[i] = gameObject.GetComponent<TargetBehavior>();
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetCount == 0)
        {
            RespawnTargets();
        }
    }

    void RespawnTargets()
    {
        if (internalTimer == 0)
        {
            score += targetFullClear;
        }
        if (internalTimer >= targetRespawnTimer)
        {
            foreach (TargetBehavior targetBehavior in targets)
            {
                targetBehavior.RespawnTarget();
            }
			internalTimer = 0;
            targetCount = 4;
		}
        else
        {
            internalTimer++;
        }
    }
}
