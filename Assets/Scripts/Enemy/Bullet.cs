using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int Damage = 10;
    [SerializeField] float Speed = 5f;

    void Update()
    {
        transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        /*if(col.TryGetComponent<PlayerHealth>(out var player))
        {

        }*/

        if(col.tag == "Player")
        {
            Debug.Log("Shoot");
        }

        Destroy(gameObject);
    }
}
