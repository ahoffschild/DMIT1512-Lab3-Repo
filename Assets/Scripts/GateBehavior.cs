using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehavior : MonoBehaviour
{
    [SerializeField] GameObject gateCorner;
    [SerializeField] GameObject gateWall;
    GateState gateState;
    [SerializeField] Color newColor;
    Color originalColor;
    [SerializeField] int gateTimer;
    int internalTimer;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = gateCorner.GetComponent<SpriteRenderer>().color;
        GateOpen();
    }

    // Update is called once per frame
    void Update()
    {
        if (gateState == GateState.Closing)
        {
            GateClose();
        }
    }

    void GateClose()
    {
        if (internalTimer >= gateTimer)
        {
            gateCorner.GetComponent<PolygonCollider2D>().isTrigger = false;
			gateWall.GetComponent<BoxCollider2D>().isTrigger = false;
			gateCorner.GetComponent<SpriteRenderer>().color = originalColor;
            gateWall.GetComponent<SpriteRenderer>().color = originalColor;
            gateState = GateState.Closed;
		}
        internalTimer++;
    }

    public void GateOpen()
    {
		gateCorner.GetComponent<PolygonCollider2D>().isTrigger = true;
		gateWall.GetComponent<BoxCollider2D>().isTrigger = true;
		gateCorner.GetComponent<SpriteRenderer>().color = newColor;
		gateWall.GetComponent<SpriteRenderer>().color = newColor;
        gateState = GateState.Open;
        internalTimer = 0;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (gateState == GateState.Open)
        {
            gateState = GateState.Closing;
        }
	}
}

public enum GateState
{
    Open,
    Closing,
    Closed
}