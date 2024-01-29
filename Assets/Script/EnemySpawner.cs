using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public Vector3 spawnPoint = new Vector3(0.35f, 1.36f, -15f); // Reference to the spawn point where enemies will be spawned

    public int spawnCount = 2; // Number of enemies to spawn when an enemy is killed

    void OnTriggerEnter(Collider other)
    {
        // Check if the thrown object collided with the enemy
        if (other.CompareTag("ThrownObject"))
        {
            // Destroy the current enemy
            Destroy(gameObject);

            // Spawn new enemies
            for (int i = 0; i < spawnCount; i++)
            {
                Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            }
        }
    }
}
