using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float Hp;
    public float MaxHp = 3000f;
    
    public Color damageColor = Color.red;
    public SpriteRenderer spriteRenderer;
    public GameObject bossPhase1;
    public GameObject bossPhase2;
    private Animator anim;

    void Start()
    {
        Hp = MaxHp;
        anim = GetComponent<Animator>();
    }
    
    public void TakeDamage(float damage)
    {
        Hp -= damage;
        StartCoroutine(ChangneColorDamage());

        if(Hp <= 1500)
        {   
            anim.SetTrigger("Phase2");
            StartCoroutine(ChangeBossPhase());
        }
        
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

    IEnumerator ChangeBossPhase()
    {
        yield return new WaitForSeconds(2.0f);
        bossPhase2.SetActive(true);
        bossPhase1.SetActive(false);

    }

}
