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
            Destroy(enemyPrefab);
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
