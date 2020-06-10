using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public VariableJoystick variableJoyStick;

    private void Update()
    {
        Vector2 moveVector = new Vector2(variableJoyStick.Horizontal, variableJoyStick.Vertical);
        transform.Translate(moveVector * Time.deltaTime);
    }
}