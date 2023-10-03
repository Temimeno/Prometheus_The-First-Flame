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

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;
        healthBar.fillAmount = CurrentHealth / MaxHealth;
        if(CurrentHealth <= 0)
        {
            Destroy(player);
            isDeath = true;
        }
    }
}
