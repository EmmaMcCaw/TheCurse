using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OrbPickUpSound : MonoBehaviour
{
    public AudioSource Hum;
    private bool collected = false;

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey(KeyCode.Space)&& collected == false)
        {
            // Hum.PlayOneShot(Hum);
            Hum.Play();
            Destroy(gameObject, 3f);
            collected = true;
        }
    }
}
