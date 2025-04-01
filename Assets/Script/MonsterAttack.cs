using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackDamage = 10f;
    private Transform player;
    private float attackCooldown = 2f;
    private float lastAttackTime = 0f;

    void Start()
    {
        // ค้นหาผู้เล่นในฉาก
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        AttackPlayer();
    }

    void AttackPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                lastAttackTime = Time.time;
                DealDamageToPlayer();
            }
        }
    }

    void DealDamageToPlayer()
    {
        // ทำการลด HP ของผู้เล่น
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);

            PlayerHealthUI playerHealthUI = player.GetComponent<PlayerHealthUI>();
            if (playerHealthUI != null)
            {
                playerHealthUI.ShowHitBorder();
            }
        }
    }
}
