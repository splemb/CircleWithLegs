using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isActive;

    public Sprite[] sprites;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") { isActive = !isActive; GetComponent<SpriteRenderer>().sprite = sprites[1]; audioSource.Play(); }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") { GetComponent<SpriteRenderer>().sprite = sprites[0]; }
    }
}
