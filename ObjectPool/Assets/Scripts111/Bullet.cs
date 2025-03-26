using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private BulletPool bulletPool;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(BulletPool pool)
    {
        bulletPool = pool;
    }

    public void Shoot(Vector2 direction, float speed)
    {
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bulletPool.ReturnBullet(gameObject);
    }
}
