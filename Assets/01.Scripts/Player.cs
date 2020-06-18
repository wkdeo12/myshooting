using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 screenMin;
    public Vector2 screenMax;
    public VariableJoystick variableJoyStick;
    private Vector2 moveVector;
    public UserShots currentShot;
    public int shotLv = 0;
    public FCS fcs;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            fcs.Lv++;
        }
    }

    private void FixedUpdate()
    {
        moveVector = new Vector2(variableJoyStick.Horizontal, variableJoyStick.Vertical);
        transform.Translate(moveVector * Time.fixedDeltaTime);
        if (variableJoyStick.push)
        {
            fcs.Shot();
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, screenMin.x, screenMax.x), Mathf.Clamp(transform.position.y, screenMin.y, screenMax.y));
    }

    public float shotDeley = 1f;
    private float duration;

    private void Shot()
    {
        switch (currentShot)
        {
            case UserShots.Fire:
                break;

            case UserShots.Ice:
                break;

            case UserShots.Thunder:
                break;

            case UserShots.Wind:
                break;

            case UserShots.Light:
                break;

            case UserShots.Darkness:
                break;

            default:
                break;
        }
    }
}