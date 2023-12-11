using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    public float Hp;
    public float MaxHp = 100;
    public Color damageColor = Color.red;
    public SpriteRenderer spriteRenderer;
    public PlayerHealth playerHealth;
    public Souls playerSouls;
    public Souls enemySouls;

    void Start()
    {
        Hp = MaxHp;
    }
    
    public void TakeDamage(float damage)
    {
        Hp -= damage;
        StartCoroutine(ChangneColorDamage());
        if(Hp <= 0)
        {
            playerSouls.soul += enemySouls.soul;
            Destroy(enemyPrefab);
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "PlayerHealth")
        {
            playerHealth.TakeDamage(10);
        }
    }

    IEnumerator ChangneColorDamage()
    {
        Color originalColor = Color.white;
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColor;
    }
}
