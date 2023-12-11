using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthPhase2 : MonoBehaviour
{
    public float Hp = 1000f;
    public float MaxHp = 2000f;
    
    public Color damageColor = Color.red;
    public SpriteRenderer spriteRenderer;
    public GameObject bossPhase2;
    public Animator anim;
    public Image bossHpBar;
    public PlayerMovement playerMovement;
    public Status playerStatus;

    public GameObject playerUI;
    public GameObject bossUI;
    public GameObject topBlock;
    public GameObject bottomBlock;
    public GameObject EndScene;

    float originCurrentHP;
    float originMaxHP;
    int originHeal;

    void Awake()
    {
        Hp = 1000;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        Hp -= damage;
        StartCoroutine(ChangneColorDamage());
        bossHpBar.fillAmount = Hp / MaxHp;

        if(Hp <= 0)
        {
            originCurrentHP = playerStatus.CurrentHealth;
            originMaxHP = playerStatus.MaxHealth;
            originHeal = playerStatus.healQuantity;
            playerStatus.MaxHealth = 100;
            playerStatus.CurrentHealth = 100;

            playerUI.SetActive(false);
            bossUI.SetActive(false);
            topBlock.SetActive(true);
            bottomBlock.SetActive(true);

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
        playerMovement.enabled = false;
        yield return new WaitForSeconds(1.5f);
        EndScene.SetActive(true);

        playerStatus.MaxHealth = originMaxHP;
        playerStatus.CurrentHealth = originCurrentHP;
        playerStatus.healQuantity = originHeal;

        Destroy(bossPhase2);
    }

}