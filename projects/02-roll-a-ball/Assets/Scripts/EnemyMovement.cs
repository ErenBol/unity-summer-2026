using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        Debug.Log("Enemy script started on: " + gameObject.name);

        if (player == null)
        {
            Debug.LogError("Player is NOT assigned.");
        }
        else
        {
            Debug.Log("Assigned player is: " + player.name);
        }

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent is missing.");
        }
    }

    void Update()
    {
        if (player == null || navMeshAgent == null)
        {
            return;
        }

        if (!navMeshAgent.isOnNavMesh)
        {
            Debug.LogError("Enemy is NOT on NavMesh.");
            return;
        }

        navMeshAgent.SetDestination(player.position);

        Debug.DrawLine(transform.position, player.position, Color.red);
    }
}