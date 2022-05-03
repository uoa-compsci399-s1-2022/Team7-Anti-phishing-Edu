using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public List<DialogueScentenceData> sentences;

    public Dialogue(List<DialogueScentenceData> sentences)
    {
        this.sentences = sentences;
    }

    public void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(this);
    }
}
