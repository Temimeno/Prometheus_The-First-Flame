using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    public float Hp;
    public float MaxHp = 100;

    void Start()
    {
        Hp = MaxHp;
    }
    
    public void TakeDamage(float damage)
    {
        Hp -= damage;
        if(Hp <= 0)
        {
            Destroy(enemyPrefab);
        }
    }
}
