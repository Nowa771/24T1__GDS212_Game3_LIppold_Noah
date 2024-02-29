using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.enabled = false; 
    }

    public void PlayOneShot(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.enabled = true;

            audioSource.PlayOneShot(clip);
        }
    }
}