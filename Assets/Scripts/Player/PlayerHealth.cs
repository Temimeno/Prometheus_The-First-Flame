using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    YouDied youDied;
    public Image healthBar;
    public GameObject player;
    public Status status;

    public bool isDeath = false;

    bool isHit = false;
    [SerializeField] Color damageColor = Color.red;
    public SpriteRenderer sr;
    Color defaultColor;

    void Start()
    {
        healthBar.fillAmount = status.CurrentHealth / status.MaxHealth;
        defaultColor = sr.color;
    }

    public void TakeDamage(float Damage)
    {
        isHit = true;
        StartCoroutine("SwitchColor");
        status.CurrentHealth -= Damage;
        healthBar.fillAmount = status.CurrentHealth / status.MaxHealth;
        if(status.CurrentHealth <= 0)
        {
            Destroy(player);
            isDeath = true;
        }
    }

    IEnumerator SwitchColor()
    {
        sr.color = damageColor;
        yield return new WaitForSeconds(0.2f);
        sr.color = defaultColor;
        isHit = false;
    }
}
