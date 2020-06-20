using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Vector2 screenMin;
    public Vector2 screenMax;
    public VariableJoystick variableJoyStick;
    private Vector2 moveVector;
    public UserShots currentShot;
    public int shotLv = 0;
    public float speed = 2f;
    public FCS fcs;
    public DragMove dragMove;

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

    public Text text;

    private void FixedUpdate()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch.deltaPosition);
            text.text = touch.deltaPosition.ToString();
            transform.Translate(touch.deltaPosition * speed * Time.fixedDeltaTime);
            fcs.Shot();
        }
#endif
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