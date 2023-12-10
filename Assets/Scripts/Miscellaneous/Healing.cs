using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    public Image hpbar;
    public Status status;
    public GameObject potion1;
    public GameObject potion2;
    public GameObject potion3;

    void Start()
    {
        if (status.healQuantity >= 1)
        {
            potion1.SetActive(true);
            if (status.healQuantity >= 2)
            {
                potion2.SetActive(true);
                if (status.healQuantity >= 3)
                {
                    potion3.SetActive(true);
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (status.healQuantity > 0)
                Heal();
        }
    }

    public void Heal()
    {
        status.CurrentHealth += status.healAmount;
        status.healQuantity -= 1;
        
        if (status.healQuantity < 3)
        {
            potion3.SetActive(false);
            if (status.healQuantity < 2)
            {
                potion2.SetActive(false);
                if (status.healQuantity < 1)
                {
                    potion1.SetActive(false);
                }
            }
        }

        if (status.CurrentHealth > status.MaxHealth)
        {
            status.CurrentHealth = status.MaxHealth;
        }

        hpbar.fillAmount = status.CurrentHealth / status.MaxHealth;
    }
}
