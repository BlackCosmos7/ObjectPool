using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CirclePool circlePool;
    [SerializeField] private List<Vector3> spawnPositions;
    [SerializeField] private float spawnDelay = 2f;

    private void Start()
    {
        StartCoroutine(SpawnCircles());
    }

    private IEnumerator SpawnCircles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            Vector3 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Count)];
            Circle circle = circlePool.GetFromPool();
            circle.transform.position = spawnPosition;
        }
    }
}
