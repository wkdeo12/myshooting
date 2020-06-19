using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zako : Enemy
{
    public float attackDuration = 1f;

    protected override void Start()
    {
        base.Start();
    }

    private void FixedUpdate()
    {
        Shot();
    }

    public override void Lv0()
    {
        var idx = GetIdx(lv);
        projectileCashList[idx].transform.position = transform.position;
        projectileCashList[idx].velocity = GetTargetPoint(transform.position - Vector3.down * 7f, transform.position);
        projectilePool[idx].SetActive(true);
    }

    public override void Lv1()
    {
        base.Lv1();
    }

    public override void Lv2()
    {
        base.Lv2();
    }

    public override void Lv3()
    {
        base.Lv3();
    }
}