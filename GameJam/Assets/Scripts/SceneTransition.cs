using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string NextScene;

    public enum Scene
    {
        StartofGame,
        Next
    }



    public void OnTriggerEnter2D(Collider2D collision)

    { 
        Debug.Log("wtf");
        if (collision.name == "Player")
        {
          Debug.Log("butch");
          SceneManager.LoadScene(NextScene);
            
        }
       
    }


    
}
