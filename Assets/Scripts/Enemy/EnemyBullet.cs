using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject SpawnBullet;
    
    public float time;
    public float timeSpawn;
    public SpriteRenderer spriteRenderer;
    public Color ShootBlaster = Color.blue;

    void Update()
    {
        time += Time.deltaTime;
        if(time >= 3)
        {
            StartCoroutine(ChangneColorBlaster());
            if(time > timeSpawn)
            {
                Shoot();
            }
        }
    }


    void Shoot()
    {
        time = 0;
        Instantiate(Bullet, SpawnBullet.transform.position, Quaternion.identity);
    }

    IEnumerator ChangneColorBlaster()
    {
        Color originalColor = Color.white;
        spriteRenderer.color = ShootBlaster;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColor;
    }
}
