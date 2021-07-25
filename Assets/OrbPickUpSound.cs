using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OrbPickUpSound : MonoBehaviour
{
    public AudioSource Hum;
    private bool collected = false;

	// Update is called once per frame
	/*void Update()
    {
      if (Input.GetKey(KeyCode.Space)&& collected == false)
        {
            // Hum.PlayOneShot(Hum);
            Hum.Play();
            Destroy(gameObject, 3f);
            collected = true;
        }
    }*/

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.name == "Player" && collected == false)
        {
            // Hum.PlayOneShot(Hum);
            Hum.Play();
            Invoke("loadScene", 3f);
            Destroy(gameObject, 3f);
            collected = true;
        }
    }


    private void loadScene()
	{
        print("EEEE");
        SceneManager.LoadScene(4);
    }
}
