using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class Sentences
{
    public string[] sentences;
    public AudioClip[] sentencesAudio;
}


[System.Serializable]
public class Dialogue
{
    public string name;
    public GameObject[] nextDialogue;
    public Sentences[] sentences;
}