using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject SpawnBullet;
    
    public float time;
    public float timeSpawn;

    void Update()
    {
        time += Time.deltaTime;
        if(time > timeSpawn)
        {
            Shoot();
        }
    }


    void Shoot()
    {
        time = 0;
        Instantiate(Bullet, SpawnBullet.transform.position, Quaternion.identity);
    }
}
