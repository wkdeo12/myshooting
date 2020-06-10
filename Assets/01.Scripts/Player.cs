using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 screenMin;
    public Vector2 screenMax;
    public VariableJoystick variableJoyStick;

    private void Update()
    {
        Vector2 moveVector = new Vector2(variableJoyStick.Horizontal, variableJoyStick.Vertical);
        transform.Translate(moveVector * Time.deltaTime);
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, screenMin.x, screenMax.x), Mathf.Clamp(transform.position.y, screenMin.y, screenMax.y));
    }
}