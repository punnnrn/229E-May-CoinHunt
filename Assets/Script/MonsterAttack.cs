using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public float attackRange = 2f;  // ระยะที่มอนสเตอร์สามารถโจมตีผู้เล่นได้
    public float attackDamage = 10f;  // ความเสียหายที่มอนสเตอร์ทำ
    private Transform player;  // ตัวแปรเก็บตำแหน่งของผู้เล่น
    private float attackCooldown = 2f;  // เวลาคูลดาวน์สำหรับการโจมตีซ้ำ
    private float lastAttackTime = 0f;  // เวลาที่มอนสเตอร์โจมตีล่าสุด

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
        // ตรวจสอบระยะการโจมตี
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            // ตรวจสอบว่าเวลาคูลดาวน์ของการโจมตีหมดหรือยัง
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                // เรียกฟังก์ชันโจมตี
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

            // เรียกฟังก์ชัน ShowHitBorder ใน PlayerHealthUI
            PlayerHealthUI playerHealthUI = player.GetComponent<PlayerHealthUI>();
            if (playerHealthUI != null)
            {
                playerHealthUI.ShowHitBorder();
            }
        }
    }
}
