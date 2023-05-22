using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudObjectSpawner : MonoBehaviour
{
    public GameObject raindropPrefab;
    public float minInterval = 0.1f;
    public float maxInterval = 0.2f;
    public int minNumRaindrops = 50;
    public int maxNumRaindrops = 75;
    public float minSize = 0.5f;
    public float maxSize = 2f;
    public float spawnRadius = 5f;
    public float minGravity = -0.5f;
    public float maxGravity = -2f;
    public float minSpeedMultiplier = 0.5f;
    public float maxSpeedMultiplier = 2f;

    private Vector3 spawnCenter;

    private void Start()
    {
        spawnCenter = transform.position;
        StartCoroutine(SpawnRaindropsCoroutine());
    }

    private IEnumerator SpawnRaindropsCoroutine()
    {
        while (true)
        {
            float interval = Random.Range(minInterval, maxInterval);
            int numRaindrops = Random.Range(minNumRaindrops, maxNumRaindrops);

            SpawnRaindrops(numRaindrops);

            yield return new WaitForSeconds(interval);
        }
    }

    private void SpawnRaindrops(int numRaindrops)
    {
        for (int i = 0; i < numRaindrops; i++)
        {
            GameObject raindrop = CreateRaindrop();
            raindrop.transform.position = GetRandomSpawnPosition();
            float size = Random.Range(minSize, maxSize);
            raindrop.transform.localScale = Vector3.one * size;

            Rigidbody rigidbody = raindrop.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                float randomGravity = Random.Range(minGravity, maxGravity);
                float speedMultiplier = Mathf.Lerp(minSpeedMultiplier, maxSpeedMultiplier, Mathf.InverseLerp(minSize, maxSize, size));
                float speed = randomGravity * speedMultiplier;

                rigidbody.useGravity = true;
                rigidbody.mass = 1f;
                rigidbody.drag = Random.Range(0.1f, 0.5f);
                rigidbody.angularDrag = Random.Range(0.1f, 0.5f);
                rigidbody.AddForce(new Vector3(0f, speed, 0f), ForceMode.VelocityChange);
            }
        }
    }

    private GameObject CreateRaindrop()
    {
        GameObject raindrop = Instantiate(raindropPrefab);
        return raindrop;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = spawnCenter + new Vector3(randomPoint.x, 0f, randomPoint.y);
        return spawnPosition;
    }
}
