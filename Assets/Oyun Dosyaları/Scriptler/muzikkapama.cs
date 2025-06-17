using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzikkapama : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Mute
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMusic();
        }
    }

    void ToggleMusic()
    {
        // kontrol
        if (audioSource.isPlaying)
        {
            // durdur
            audioSource.Stop();
        }
        else
        {
            // baslat
            audioSource.Play();
        }
    }
}