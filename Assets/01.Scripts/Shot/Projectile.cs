using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float speed = 2f;
    public FxPool fxPool;

    private void Start()
    {
        fxPool = FindObjectOfType<FxPool>();
    }

    protected virtual void FixedUpdate()
    {
        Action();
    }

    protected virtual void Action()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Bound")
        {
            collision.GetComponent<Enemy>().CurrentHp -= damage;
            var fx = fxPool.GetHitFx();
            fx.transform.position = collision.bounds.ClosestPoint(transform.position);
            fx.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}