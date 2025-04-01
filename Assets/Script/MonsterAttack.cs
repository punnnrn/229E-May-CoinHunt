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
    RaycastHit hit;
    Vector3 direction = (player.position - transform.position).normalized;

    if (Physics.Raycast(transform.position, direction, out hit, attackRange))
    {
        if (hit.collider.CompareTag("Player") && Time.time - lastAttackTime >= attackCooldown)
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
