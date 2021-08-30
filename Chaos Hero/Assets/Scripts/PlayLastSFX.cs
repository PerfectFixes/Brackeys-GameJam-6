using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLastSFX : MonoBehaviour
{
    private bool isLast = true;

    public AudioSource audioManager;
    public AudioClip finalSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isLast)
        {

            if (PlayerPrefs.GetInt("debuffsCount") == 0)
            {
                audioManager.PlayOneShot(finalSFX);
                isLast = false;
            }
        }
    }
}
