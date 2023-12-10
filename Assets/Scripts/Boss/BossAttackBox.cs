using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackBox : MonoBehaviour
{
    public int Damage = 10;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "PlayerHealth")
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }
    }
}
