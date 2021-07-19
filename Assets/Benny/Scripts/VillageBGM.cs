using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageBGM : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioSource audioSourceSFXCough;
    public AudioSource audioSourceSFXCry;

    public AudioClip villageLoop1;
    public AudioClip villageLoop2;
    [SerializeField] private bool curseLifted;

    public AudioClip[] Coughs;
    public AudioClip[] Cries;
    public AudioClip[] Other;

    [SerializeField] private float coughTimer;
    private float coughTimerMAX;

    private float cryTimer;
    private float cryTimerMAX;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (curseLifted) { audioSource.clip = villageLoop1; }
        if (!curseLifted) { audioSource.clip = villageLoop2; }
        audioSource.Play();

        coughTimerMAX = Random.Range(3, 7);
        cryTimerMAX = Random.Range(5, 15);
    }

	private void Update()
	{
        coughTimer += 1 * Time.deltaTime;
        if (coughTimer > coughTimerMAX)
		{
            coughTimer = 0;
            coughTimerMAX = Random.Range(3, 7);
            audioSourceSFXCough.clip = Coughs[Random.Range(0, Coughs.Length - 1)];
            audioSourceSFXCough.Play();
        }


        cryTimer += 1 * Time.deltaTime;
        if (cryTimer > cryTimerMAX)
        {
            cryTimer = 0;
            cryTimerMAX = Random.Range(5, 15);
            audioSourceSFXCry.clip = Cries[Random.Range(0, Cries.Length - 1)];
            audioSourceSFXCry.Play();
        }
    }
}
