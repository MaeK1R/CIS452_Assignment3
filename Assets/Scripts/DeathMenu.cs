/*
 * Matt Kirchoff
 * DeathMenu.cs
 * Assignment 3
 * Death menu controller
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(sceneName: "GameScene");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName: "MainMenu");
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
