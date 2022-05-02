using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueScentenceData 
{
    public Sprite characterPortrait;

    public string characterName = "CHARACTER NAME";
    [TextArea(4,10)]public string sentenceContent = "SENTENCE CONTENT";

    public bool hasChoices;
    public List<DialogueChoice> choiceContent;

    public IEnumerator GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}


