using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueScentenceData 
{
    public Sprite characterPortrait;

    public string characterName = "CHARACTER NAME";
    [TextArea(4,10)]public string sentenceContent = "SENTENCE CONTENT";

    public SentenceActionType actionType;
    public string sceneName = "";

    public bool hasChoices;
    public List<DialogueChoiceData> choiceContent;

    public IEnumerator GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}

public enum SentenceActionType
{
    None,
    Shake,
    EnterTutorialScene,
    Transmission,
    EnterNextScene,
}


