using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthPhase2 : MonoBehaviour
{
    public float Hp = 1250f;
    public float MaxHp = 2500f;
    
    public Color damageColor = Color.red;
    public SpriteRenderer spriteRenderer;
    public GameObject bossPhase2;
    public Animator anim;
    public Image bossHpBar;

    void Awake()
    {
        Hp = 1250;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        Hp -= damage;
        StartCoroutine(ChangneColorDamage());
        bossHpBar.fillAmount = Hp / MaxHp;

        if(Hp <= 0)
        {
            anim.SetTrigger("Death");
            StartCoroutine(BossDeath());
        }
    }

    IEnumerator ChangneColorDamage()
    {
        Color originalColor = Color.white;
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColor;
    }

    IEnumerator BossDeath()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(bossPhase2);
    }

}