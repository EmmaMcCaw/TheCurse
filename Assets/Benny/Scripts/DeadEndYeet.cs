using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// This is where characters dialogue goes in the inspector

public class DeadEndYeet : MonoBehaviour
{
    private GameObject player;
    public int sceneToLoad;

    private void Start()
    {
        player = GameObject.Find("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
