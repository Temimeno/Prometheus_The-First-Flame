using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    YouDied youDied;
    public Image healthBar;
    public GameObject player;

    public float MaxHealth = 50;
    public float CurrentHealth;
    public bool isDeath = false;

    bool isHit = false;
    [SerializeField] Color damageColor = Color.red;
    public SpriteRenderer sr;
    Color defaultColor;

    void Start()
    {
        CurrentHealth = MaxHealth;
        defaultColor = sr.color;
    }

    public void TakeDamage(float Damage)
    {
        isHit = true;
        StartCoroutine("SwitchColor");
        CurrentHealth -= Damage;
        healthBar.fillAmount = CurrentHealth / MaxHealth;
        if(CurrentHealth <= 0)
        {
            Destroy(player);
            isDeath = true;
        }
    }

    IEnumerator SwitchColor()
    {
        sr.color = damageColor;
        yield return new WaitForSeconds(0.2f);
        sr.color = defaultColor;
        isHit = false;
    }
}
