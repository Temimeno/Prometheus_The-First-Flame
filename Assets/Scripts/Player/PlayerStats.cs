using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stats stats;
    public Souls souls;
    public Status status;

    void Start()
    {
        status.MaxHealth = 0;
        status.CurrentHealth = 0;
        status.attackDamage = 0;
        status.dashingCooldown = 0.8f;
        status.healQuantity = 3;
    }


    void Update()
    {
        
    }
}