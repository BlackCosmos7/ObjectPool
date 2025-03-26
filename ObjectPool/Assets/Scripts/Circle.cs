using UnityEngine;

public class Circle : MonoBehaviour
{
    private CirclePool pool;

    public void Initialize(CirclePool pool)
    {
        this.pool = pool;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            pool.ReturnToPool(this);
        }
    }
}