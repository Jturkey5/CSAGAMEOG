using UnityEngine;

public class GoopSpawner : MonoBehaviour
{
    public GameObject goopPrefab;
    public float spawnInterval = 1f;
    public float randomInterval = 0.5f;
    public float spawnDuration = 20f;
    public float maxSpawnRadius = 4f;

    private float spawnIntervalElapsed = 0f;
    private float spawnDurationElapsed = 0f;

    private void Update()
    {
        spawnDurationElapsed += Time.deltaTime;

        if (spawnDurationElapsed >= spawnDuration)
        {
            StopSpawning();
        }
        else
        {
            spawnIntervalElapsed += Time.deltaTime;

            if (spawnIntervalElapsed >= spawnInterval)
            {
                float interval = spawnInterval + Random.Range(-randomInterval, randomInterval);
                Vector3 spawnPosition = transform.position + Random.insideUnitSphere * maxSpawnRadius;
                Instantiate(goopPrefab, spawnPosition, Quaternion.identity);
                spawnIntervalElapsed = 0f;
            }
        }
    }

    public void StopSpawning()
    {
        enabled = false;
    }
}
