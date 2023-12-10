using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    //[SerializeField] int Damage = 10;
    [SerializeField] float timer;
    [SerializeField] float timerDestroy = 10f;

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
}
