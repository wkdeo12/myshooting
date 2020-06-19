using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : FCS
{
    private Vector2 pivot;

    public override void Lv0()
    {
        var go = GetBullet(Lv);
        pivot = transform.position + Vector3.up * 0.1f;
        go.transform.position = pivot;
        go.SetActive(true);

        audio.Play();
    }

    private float noise = 0.05f;

    public override void Lv1()
    {
        var go = GetBullet(Lv);
        pivot = transform.position + Vector3.up * 0.1f;
        pivot.x += noise;
        go.transform.position = pivot;

        go.SetActive(true);
        noise *= -1f;
        audio.Play();
    }

    public override void LvUP()
    {
        delay *= 0.7f;
    }

    public override void Lv2()
    {
        var go = GetBullet(Lv);
        pivot = transform.position + Vector3.up * 0.1f;
        pivot.x += Random.Range(0, noise);
        go.transform.position = pivot;

        go.SetActive(true);
        noise *= -1f;
        audio.Play();
    }

    public override void Lv3()
    {
        base.Lv3();
    }
}