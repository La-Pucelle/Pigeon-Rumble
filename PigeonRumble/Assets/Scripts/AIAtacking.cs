using UnityEngine;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform; // Transform del jugador
    private NavMeshAgent agent;       // El NavMeshAgent

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Obtener el componente NavMeshAgent
    }

    void Update()
    {
        if (playerTransform != null)
        {
            agent.SetDestination(playerTransform.position); // Establecer el destino del NavMeshAgent como la posición del jugador
        }
    }
}
