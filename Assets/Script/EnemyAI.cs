using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform player; // Reference to the player's transform
    private NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component

    void Start()
    {
        // Find the player object by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the NavMeshAgent component attached to this GameObject
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Set the destination of the NavMeshAgent to the player's position initially
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    void Update()
    {
        // Update the destination of the NavMeshAgent to the player's position
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }
}
