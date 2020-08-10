using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlecontroller : MonoBehaviour
{

    public bool exit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (exit) Application.Quit();
            else SceneManager.LoadScene(1);
        }
    }
}
