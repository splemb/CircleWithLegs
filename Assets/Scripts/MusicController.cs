using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    public float musicPosition;
    public PlayerController player;
    public bool posStored;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Store")) { musicPosition = audioSource.time; posStored = true; }
        if (posStored && Input.GetButtonDown("Release")) { audioSource.time = musicPosition; posStored = false; }

        if (Input.GetKeyDown(KeyCode.M)) audioSource.mute = !audioSource.mute;
    }
}
