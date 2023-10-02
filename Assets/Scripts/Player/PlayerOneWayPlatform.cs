using System.Collections;
using System.Collections.Generic; // Add this line
using UnityEngine;

public class PlayerOneWayPlatform : MonoBehaviour
{
    private GameObject currentOneWayPlatform;

    public List<BoxCollider2D> playerCollider = new List<BoxCollider2D>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            if (currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();

        foreach (BoxCollider2D playerColliderElement in playerCollider)
        {
            Physics2D.IgnoreCollision(playerColliderElement, platformCollider);
        }

        yield return new WaitForSeconds(0.5f);

        foreach (BoxCollider2D playerColliderElement in playerCollider)
        {
            Physics2D.IgnoreCollision(playerColliderElement, platformCollider, false);
        }
    }

}
