using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
        if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
