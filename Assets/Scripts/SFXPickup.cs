using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPickup : MonoBehaviour
{
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider hitRate)
    {
        if (hitRate.tag == "Player")
        {
            audioSource.Play();
        }

    }
}
