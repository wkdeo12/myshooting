using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TestManager : MonoBehaviour
{
    public InputField InputField;

    public void SetSpeed()
    {
        FindObjectOfType<Player>().speed = Convert.ToSingle(InputField.text);
    }
}