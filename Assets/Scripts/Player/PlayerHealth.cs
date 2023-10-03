using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player;
    YouDied youDied;
    public int MaxHealth = 50;
    public int CurrentHealth;
    public bool isDeath = false;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
        if(CurrentHealth <= 0)
        {
            Destroy(player);
            isDeath = true;
        }
    }
}
