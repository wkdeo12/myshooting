using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public int lv;

    private void FixedUpdate()
    {
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
                transform.Translate(Vector2.up * 2f * Time.deltaTime);
                break;

            case 1:
                break;

            case 2:
                break;

            case 3:
                break;

            default:
                break;
        }
    }
}