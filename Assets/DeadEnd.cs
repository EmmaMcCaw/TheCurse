using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// This is where characters dialogue goes in the inspector

public class DeadEnd : MonoBehaviour
{
    private GameObject player;
    

    


    private void Start()
    {
       

        player = GameObject.Find("Player");
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            //Debug villageaftercursescene
        }
    }


    


    
}
