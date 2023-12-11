using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthPhase2 : MonoBehaviour
{
    public float Hp = 1500f;
    public float MaxHp = 3000f;
    
    public Color damageColor = Color.red;
    public SpriteRenderer spriteRenderer;
    public GameObject bossPhase2;
    private Animator anim;
    public Image bossHpBar;
    void Start()
    {
        Hp = 1500;
        anim = GetComponent<Animator>();
    }
    
    public void TakeDamage(float damage)
    {
        Hp -= damage;
        StartCoroutine(ChangneColorDamage());
        bossHpBar.fillAmount = Hp / MaxHp;

        if(Hp <= 0)
        {
            Destroy(bossPhase2);
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