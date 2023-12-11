using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemyLayers;
    public LayerMask bosslayers;
    public LayerMask bosslayerPhase2;
    public Status status;
    public PlayerMovement playerMovement;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackTriggerDelay = 0.2f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    void Update()
    {
        if (Time.time >= nextAttackTime && playerMovement.isGrounded == true && playerMovement.isDashing == false)
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
        
        Collider2D[] hitbossPhase2 = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bosslayerPhase2);


        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(status.attackDamage);
        }

        foreach (Collider2D boss in hitboss)
        {
            boss.GetComponent<BossHealth>().TakeDamage(status.attackDamage);
        }

        foreach (Collider2D boss2 in hitbossPhase2)
        {
            boss2.GetComponent<BossHealthPhase2>().TakeDamage(status.attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
