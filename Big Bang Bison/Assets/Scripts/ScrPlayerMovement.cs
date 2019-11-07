using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlayerMovement : MonoBehaviour
{
    public bool arrowKeys;

    public float hspeed = 0;
    public float vspeed = 0;
    public float speedMax = 0.1f;
    public float speedIncr = 0.02f;

    private float hspeedDest = 0;
    private float vspeedDest = 0;
    private KeyCode upKey;
    private KeyCode downKey;
    private KeyCode leftKey;
    private KeyCode rightKey;

    void Start()
    {
        upKey = (arrowKeys) ? KeyCode.UpArrow : KeyCode.W;
        downKey = (arrowKeys) ? KeyCode.DownArrow : KeyCode.S;
        leftKey = (arrowKeys) ? KeyCode.LeftArrow : KeyCode.A;
        rightKey = (arrowKeys) ? KeyCode.RightArrow : KeyCode.D;
    }

    void Update()
    {
        if (Input.GetKey(upKey))
        {
            vspeedDest = speedMax;
        }
        else if (Input.GetKey(downKey))
        {
            vspeedDest = -speedMax;
        }
        else {
            vspeedDest = 0;
        }

        if (Input.GetKey(rightKey))
        {
            hspeedDest = speedMax;
        }
        else if (Input.GetKey(leftKey))
        {
            hspeedDest = -speedMax;
        }
        else {
            hspeedDest = 0;
        }

        hspeed = Mathf.Lerp(hspeed, hspeedDest, speedIncr);
        vspeed = Mathf.Lerp(vspeed, vspeedDest, speedIncr);
        transform.position = new Vector3(transform.position.x + hspeed, transform.position.y, transform.position.z + vspeed);
    }
}
