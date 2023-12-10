using UnityEngine;

[CreateAssetMenu]
public class Status : ScriptableObject
{
    public float MaxHealth;
    public float CurrentHealth;
    public float attackDamage;
    public float dashingCooldown;
    public float healAmount = 30;
    public int healQuantity;
    
}
