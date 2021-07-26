using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// This is where characters dialogue goes in the inspector

public class EnterHouse : MonoBehaviour
{
    private GameObject player;
    public string interactMessage;
    private bool mee = false;

    private TextMeshProUGUI interactText;
    private GameObject TextBorder;
    public int sceneToLoad;

    private void Start()
	{
        interactText = GameObject.Find("InteractText").GetComponent<TextMeshProUGUI>();
        TextBorder = GameObject.Find("TextBorder");

        player = GameObject.Find("Player");
    }

	public void TriggerDialogue()
	{
		if (player.GetComponent<CharacterController2D>().enabled)
		{
            print("yere");
            mee = false;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(sceneToLoad);
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.name == "Player" && collision.GetComponent<CharacterController2D>().enabled)
        {
            mee = true;
            collision.GetComponent<CharacterController2D>().canTalk = true;
            interactText.text = "PRESS \"E\" TO " + interactMessage;
            interactText.enabled = true;
            TextBorder.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            mee = false;
            collision.GetComponent<CharacterController2D>().canTalk = false;
            interactText.enabled = false;
            TextBorder.SetActive(false);
        }
    }


	private void Update()
	{
        if (mee == true)
        {
            if (Input.GetKey(KeyCode.E) && player.GetComponent<CharacterController2D>().canTalk)
            {
                TriggerDialogue();
                interactText.enabled = false;
            }
        }
    }
}
