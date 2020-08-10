using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    public PlayerController playerController;

    private void Update()
    {
        transform.position = playerController.storedPos + (Vector3.up * 0.5f);
        if (Input.GetButtonDown("Store")) GetComponent<SpriteRenderer>().flipX = playerController.GetComponentInChildren<SpriteRenderer>().flipX;
        if (playerController.posStored) GetComponent<SpriteRenderer>().enabled = true;
        else GetComponent<SpriteRenderer>().enabled = false;
    }
}
