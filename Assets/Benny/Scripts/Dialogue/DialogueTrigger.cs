using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This is where characters dialogue goes in the inspector

public class DialogueTrigger : MonoBehaviour
{
	private GameObject nameText;
    private GameObject dialogueText;
    private GameObject dialogueBox;
    private GameObject player;
    public string interactMessage;
    private bool mee = false;

    public Dialogue dialogue;

    private TextMeshProUGUI interactText;
    private GameObject TextBorder;


    private void Start()
	{
        interactText = GameObject.Find("InteractText").GetComponent<TextMeshProUGUI>();
        TextBorder = GameObject.Find("TextBorder");

        nameText = GameObject.Find("DialogueName");
        dialogueText = GameObject.Find("DialogueText");
        dialogueBox = GameObject.Find("DialogueBox");
        player = GameObject.Find("Player");

        //TextBorder.SetActive(false);
        //interactText.text = "";
        //dialogueText.SetActive(false);
        //nameText.SetActive(false);
    }

	public void TriggerDialogue()
	{
		if (player.GetComponent<CharacterController2D>().enabled)
		{
            mee = false;
            nameText.SetActive(true);
            nameText.GetComponent<TextMeshProUGUI>().enabled = true;
            nameText.GetComponent<TextMeshProUGUI>().text = dialogue.name;
            dialogueText.SetActive(true);
			dialogueText.GetComponent<TextMeshProUGUI>().enabled = true;
			player.GetComponent<CharacterController2D>().enabled = false;
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
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
                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                TriggerDialogue();
                interactText.enabled = false;
                player.GetComponent<CharacterController2D>().canTalk = false;
                player.GetComponent<CharacterController2D>().enabled = false;
            }
        }
    }
}
