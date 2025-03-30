using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public Transform player;
    public float followRange = 10f;
    public float attackRange = 2f;
    public float moveSpeed = 3.5f;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= followRange)
            {
                if (distance > attackRange)
                {
                    agent.SetDestination(player.position);
                }
                else
                {
                    agent.ResetPath();
                }
            }
        }
    }
}
