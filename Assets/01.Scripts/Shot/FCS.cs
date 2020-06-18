﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCS : MonoBehaviour
{
    protected int lv = 0;

    public int Lv
    {
        set
        {
            lv = value;
            StartCoroutine(DestroyBullet(projectilePool));
            projectilePool = new List<GameObject>();
            LvUP();
        }
        get
        {
            return lv;
        }
    }

    public GameObject[] projectile;
    public List<GameObject> projectilePool;
    public float delay = 0.25f;
    public float duration = 0.25f;

    private void Start()
    {
        duration = delay;
    }

    public virtual void Shot()
    {
        duration -= Time.fixedDeltaTime;
        if (duration > 0f)
        {
            return;
        }
        duration = delay;
        switch (lv)
        {
            case 0:
                Lv0();
                break;

            case 1:
                Lv1();
                break;

            case 2:
                Lv2();
                break;

            case 3:
                Lv3();
                break;

            default:
                break;
        }
    }

    public virtual void Lv0()
    {
    }

    public virtual void Lv1()
    {
    }

    public virtual void Lv2()
    {
    }

    public virtual void Lv3()
    {
    }

    public virtual void LvUP()
    {
    }

    public GameObject GetBullet(int lv)
    {
        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (projectilePool[i].activeSelf)
            {
                continue;
            }
            else
            {
                return projectilePool[i];
            }
        }
        var go = Instantiate(projectile[lv]);
        projectilePool.Add(go);
        return go;
    }

    private IEnumerator DestroyBullet(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            DestroyImmediate(list[i]);
            yield return new WaitForSeconds(1f);
        }
        list = null;
        yield break;
    }
}