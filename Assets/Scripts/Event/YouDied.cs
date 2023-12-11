using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDied : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] GameObject YouDiedUI;
    public PlayerMovement playerMovement;
    void Update()
    {
        if (playerHealth.isDeath == true)
        {
            YouDiedUI.SetActive(true);
        }
    }
}
