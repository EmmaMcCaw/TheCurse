using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI interactText;
    public GameObject dialogueBox;
    public GameObject dialogueBorder;
    public AudioSource _audiosource;
    private Dialogue dialoguee;
    private int currentSentence;

    private Queue<string> sentences;

    public float dialogueDelaySpeed;

    public void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        GameObject.Find("PlayerFootsteps").GetComponent<AudioSource>().Stop();
        dialoguee = dialogue;
        currentSentence = -1;

        //interactText.text = "";
        nameText.enabled = true;
        dialogueText.enabled = true;
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences[0].sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if(currentSentence < dialoguee.sentences.Length)
        {
            currentSentence += 1;
            _audiosource.clip = dialoguee.sentences[0].sentencesAudio[currentSentence];
            //print(currentSentence);
            _audiosource.Stop();
            _audiosource.Play();
        }
        
        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        // _audiosource.clip = dialoguee.sentences[sentence].sentencesAudio[sentence];
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            // This would make text type every frame
            //yield return null;
            yield return new WaitForSeconds(dialogueDelaySpeed);
        }
    }

    public void EndDialogue()
    {



            if (dialoguee.nextDialogue.Length > 0)
            {
                print("testfolb");
                // if (dialoguee.nextDialogue[0].gameObject.GetComponent<DialogueTrigger>() != null)
                {
                    StartDialogue(dialoguee.nextDialogue[0].gameObject.GetComponent<DialogueTrigger>().dialogue);
                }
                // if (dialoguee.nextDialogue[0].gameObject.GetComponent<DialogueTriggerAuto>() != null)
                //  {
                //    StartDialogue(dialoguee.nextDialogue[0].gameObject.GetComponent<DialogueTriggerAuto>().dialogue);
                //  }
            }
        
        else
        {



            var player = GameObject.Find("Player");
            player.SetActive(true);

            player.GetComponent<CharacterController2D>().enabled = true;

            //GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>().enabled = false;
            dialogueText.GetComponent<TextMeshProUGUI>().enabled = false;
            interactText.text = "";
            dialogueBorder.SetActive(false);
            //dialogueText.text = "";
            //nameText.text = "";
            nameText.enabled = false;
            interactText.GetComponent<TextMeshProUGUI>().enabled = true;
            //Debug.Log("End of conversation");
            _audiosource.Stop();
        }
    }




    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (dialogueText.enabled)
            {
                DisplayNextSentence();
            }
        }
    }
}
