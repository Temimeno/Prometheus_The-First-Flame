using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int Damage = 10;
    [SerializeField] float Speed = 5f;
    [SerializeField] float timerDead = 10f;
    [SerializeField] float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timerDead)
        {
            Destroy(gameObject);
        }
        transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "PlayerHealth")
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }

        Destroy(gameObject);
    }
}
