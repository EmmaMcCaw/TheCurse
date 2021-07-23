using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OrbPickUpSound : MonoBehaviour
{
    //public AudioSource Hum;
     

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey(KeyCode.Space))
        {
           // Hum.PlayOneShot(Hum);
            Destroy(gameObject, 3f);
        }
    }
}
