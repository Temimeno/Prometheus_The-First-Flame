using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemyLayers;
    public LayerMask bosslayers;
    public Status status;
    public PlayerMovement playerMovement;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;
    public float attackTriggerDelay = 0.2f;
    bool canAttack = true;

    void Update()
    {
        if (Time.time >= nextAttackTime && playerMovement.isGrounded == true && playerMovement.isDashing == false)
        {
            if (Input.GetKeyDown(KeyCode.J) && canAttack)
            {
                animator.SetTrigger("Attack");
                StartCoroutine(AttackWithDelay());
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    IEnumerator AttackWithDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackTriggerDelay);
        Attack();
        canAttack = true;
    }

    void Attack()
    {
        // Detect enemies and damage them
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