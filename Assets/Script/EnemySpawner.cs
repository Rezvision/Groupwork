using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject text; // Reference to the enemy prefab
    public float spawnRadius = 20f; // Maximum distance from the spawn point to randomize
    public int spawnCount = 2; // Number of enemies to spawn when an enemy is killed
    private static int totalEnemiesSpawned = 0; // Total number of enemies spawned by all instances of the script
    public TextMeshPro enemyCountText;  // Reference to the TextMeshPro component to display the enemy count
    public PlayerHealth playerHealth;

    void Start()
    {
        // Find the TextMeshPro object in the scene based on the tag
        playerHealth = GameObject.FindAnyObjectByType<PlayerHealth>();

        // Get the TextMeshPro component from the found object
        if (playerHealth != null)
        {
            enemyCountText = playerHealth.enemyCountText;
        }
        else
        {
            Debug.LogError("TextMeshPro object not found with the specified tag.");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the thrown object collided with the enemy
        if (other.CompareTag("ThrownObject"))
        {
            // Increment the total count of enemies spawned
            totalEnemiesSpawned += spawnCount;

            // Debug log the number of enemies spawned
            Debug.Log("Total enemies spawned: " + totalEnemiesSpawned);

            if (enemyCountText != null)
            {
                enemyCountText.text = "Enemy Count: " + totalEnemiesSpawned;
            }
            // Spawn new enemies
            for (int i = 0; i < spawnCount; i++)
            {
                // Calculate random offsets for X and Z axes
                float randomX = Random.Range(-spawnRadius, spawnRadius);
                float randomZ = Random.Range(-spawnRadius, spawnRadius);

                // Create a new spawn position with random offsets
                Vector3 spawnPosition = transform.position + new Vector3(randomX, 0.5f, randomZ);

                // Instantiate enemy at the randomized spawn position
                Instantiate(gameObject, spawnPosition, Quaternion.identity);
                Debug.Log(spawnPosition);

                if (text != null)
                {
                    Destroy(text);
                }
            }
        //Destroy the current enemy
        Destroy(gameObject);
        }

    }
}
