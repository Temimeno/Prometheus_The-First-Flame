using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemyLayers;
    public LayerMask bosslayers;
    public Status status;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackTriggerDelay = 0.2f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                animator.SetTrigger("Attack");
                Invoke("Attack", attackTriggerDelay);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //Detect enemies and Damaged them
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        Collider2D[] hitboss = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bosslayers);


        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(status.attackDamage);
        }

        foreach (Collider2D boss in hitboss)
        {
            boss.GetComponent<BossHealth>().TakeDamage(status.attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
