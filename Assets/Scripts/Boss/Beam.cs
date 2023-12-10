using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float timer;
    public float timerDestroy;
    
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        timer += Time.deltaTime;
        anim.SetTrigger("BeamAttack");
        if(timer > timerDestroy)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<PlayerHealth>().TakeDamage(10);
        }
    }

}
