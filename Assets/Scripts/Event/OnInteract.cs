using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInteract : MonoBehaviour
{
    public GameObject tutorialUI;
    public GameObject interactUI;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "PlayerHealth")
        {
            interactUI.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            tutorialUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == "PlayerHealth")
        {
            tutorialUI.SetActive(false);
            interactUI.SetActive(false);
        }
    }
}
