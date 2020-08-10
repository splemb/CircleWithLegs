using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Sprite[] sprites;
    public ButtonController button;
    private BoxCollider2D boxCollider;

    public bool defaultState;
    private bool state;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        GetComponent<SpriteRenderer>().color = button.GetComponent<SpriteRenderer>().color;
        state = defaultState;
    }

    // Update is called once per frame
    void Update()
    {
        boxCollider.enabled = state;
        if (state) GetComponent<SpriteRenderer>().sprite = sprites[0];
        else GetComponent<SpriteRenderer>().sprite = sprites[1];

        if (defaultState) state = !button.isActive;
        else state = button.isActive;
    }
}
