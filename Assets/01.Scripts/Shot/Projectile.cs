using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public int lv;
    public GameObject bullet;

    protected virtual void FixedUpdate()
    {
        Shot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    public virtual void Shot()
    {
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
}