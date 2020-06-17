using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string name;
    public int gold = 0;
    public float playTime = 0f;
    public int killCount = 0;
    public float maxHp = 10f;
    public float moveSpeed = 1f;
}