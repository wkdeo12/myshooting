using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyFCS
{
    public float maxHp = 1;
    private float currenHp;
    private MonsterDestroyManager destroyManager;
    public GameObject player;

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

    protected override void Start()
    {
        base.Start();
        currenHp = maxHp;
        destroyManager = FindObjectOfType<MonsterDestroyManager>();
        player = FindObjectOfType<Player>().gameObject;
    }

    private void OnDisable()
    {
        destroyManager.PlayDestoryFx(1, transform.position);
    }
}