using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongOpenBoss : MonoBehaviour
{
    public AudioSource audioClip;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "PlayerHealth")
        {
            audioClip.Play();
            StartCoroutine(CloseSong());

        }
    }

    IEnumerator CloseSong()
    {
        yield return new WaitForSeconds(6f);
        audioClip.Pause();
        Destroy(gameObject);
    }
}
