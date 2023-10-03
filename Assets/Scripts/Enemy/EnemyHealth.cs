using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Hp;
    public int MaxHp = 100;

    void Start()
    {
        Hp = MaxHp;
    }
    
    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if(Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
