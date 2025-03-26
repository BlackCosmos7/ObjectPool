using System.Collections.Generic;
using UnityEngine;

public class CirclePool : MonoBehaviour
{
    [SerializeField] private Circle circlePrefab;
    [SerializeField] private int startPoolSize = 5; 

    private Queue<Circle> pool = new Queue<Circle>();

    private void Awake()
    {
        for (int i = 0; i < startPoolSize; i++)
        {
            Circle circle = Instantiate(circlePrefab);
            circle.gameObject.SetActive(false);
            pool.Enqueue(circle);
        }
    }

    public Circle GetFromPool()
    {
        if (pool.Count > 0)
        {
            Circle circle = pool.Dequeue();
            circle.gameObject.SetActive(true);
            return circle;
        }
        else
        {
            Circle circle = Instantiate(circlePrefab);
            circle.gameObject.SetActive(true);
            return circle;
        }
    }

    public void ReturnToPool(Circle circle)
    {
        circle.gameObject.SetActive(false);
        pool.Enqueue(circle);
    }
}