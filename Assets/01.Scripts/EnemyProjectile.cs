using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    protected override void Action()
    {
        transform.Translate(velocity * speed * Time.fixedDeltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}