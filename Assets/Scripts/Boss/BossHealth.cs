using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float Hp;
    public float MaxHp = 5000f;
    
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
            Destroy(gameObject);
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
