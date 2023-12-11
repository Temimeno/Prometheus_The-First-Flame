using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float Hp;
    public float MaxHp = 2500f;
    
    public Color damageColor = Color.red;
    public SpriteRenderer spriteRenderer;
    public GameObject bossPhase1;
    public GameObject bossPhase2;
    public Animator anim;
    public Image bossHpBar;

    public bool ChangeBoss = false;

    void Awake()
    {
        Hp = MaxHp;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Hp <= 1250 && ChangeBoss == false)
        {   
            anim.SetTrigger("Phase2");
            StartCoroutine(ChangeBossPhase());
            ChangeBoss = true;
        }
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

    IEnumerator ChangeBossPhase()
    {
        yield return new WaitForSeconds(2f);
        bossPhase2.SetActive(true);
        bossPhase1.SetActive(false);

    }

}
