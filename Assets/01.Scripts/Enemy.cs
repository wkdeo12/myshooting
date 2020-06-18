using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHp = 1;
    private float currenHp;

    public float CurrentHp
    {
        get
        {
            return currenHp;
        }
        set
        {
            currenHp = value;
            if (currenHp < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void Start()
    {
        currenHp = maxHp;
    }
}