using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlayerMovement : MonoBehaviour
{
    public bool Player2;

    public float hspeed = 0;
    public float vspeed = 0;
    public float speedMax = 0.1f;
    public float speedIncr = 0.02f;
    public float speed = 5.0f;

    private float hspeedDest = 0;
    private float vspeedDest = 0;
    private KeyCode upKey;
    private KeyCode downKey;
    private KeyCode leftKey;
    private KeyCode rightKey;
    private Vector3 movement;
    private string player_horizontal;
    private string player_vertical;

    void Start()
    {
        upKey = (Player2) ? KeyCode.UpArrow : KeyCode.W;
        downKey = (Player2) ? KeyCode.DownArrow : KeyCode.S;
        leftKey = (Player2) ? KeyCode.LeftArrow : KeyCode.A;
        rightKey = (Player2) ? KeyCode.RightArrow : KeyCode.D;
        if (Player2)
        {
            player_horizontal = "Horizontal_Player2";
            player_vertical = "Vertical_Player2";
        }
        else
        {
            player_horizontal = "Horizontal_Player1";
            player_vertical = "Vertical_Player1";
        }

        /*This is for debugging and figuring out what joynum to set the controllers to if needed*/

        /*string[] joystick_array = Input.GetJoystickNames();
        Debug.Log("length of array: " + joystick_array.Length);
        for (int i = 0; i < joystick_array.Length; i++)
        {
            string content = joystick_array[i];
            if (content.Contains("Controller"))
            {
                Debug.Log("controller found at position " + i + 1);
            }
        }*/ 
    }

    void Update()
    {

        float horizontal = Input.GetAxisRaw(player_horizontal);
        float vertical = Input.GetAxisRaw(player_vertical);

        if (Input.GetKey(upKey) || vertical == -1.0f)
        {
            vspeedDest = speedMax;
        }
        else if (Input.GetKey(downKey) || vertical == 1.0f)
        {
            vspeedDest = -speedMax;
        }
        else {
            vspeedDest = 0;
        }

        if (Input.GetKey(rightKey) || horizontal == 1.0f)
        {
            hspeedDest = speedMax;
        }
        else if (Input.GetKey(leftKey) || horizontal == -1.0f)
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
