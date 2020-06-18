using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIre : Projectile
{
    public override void Lv0()
    {
        transform.Translate(Vector2.up * 2f * Time.deltaTime);
    }

    public override void Lv1()
    {
    }

    public override void Lv2()
    {
    }

    public override void Lv3()
    {
    }
}