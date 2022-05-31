using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EmailScriptableObject", menuName = "ScriptableObjects/EmailScriptableObject")]
public class EmailScriptableObject : ScriptableObject
{
    public int itemIndex;

    [Header("UI")]
    public Sprite senderIcon;
    public Sprite EmailIconNotRead;
    public Sprite EmailIconRead;

    [Header("DATA")]
    public string senderName;
    public string senderEmailAddress;
    public string senderTime;
    public string relatedSceneName;

    public string emailTitle;
    [TextArea(10,10)]public string emailContent;

    public bool hasRead;

    public EmailType emailType;

    public PlayerAns playerAns;

    private bool playerChoice;

    public void ChangeReadState(bool newState)
    {
        hasRead = newState;
    }

    public bool GetPlayerChoice()
    {
        return playerChoice;
    }

    public void SetPlayerChoice(bool playerChoice)
    {
        this.playerChoice = playerChoice;
    }


}

public enum EmailType
{
    NORMAL,
    PHISHING, 
}

public enum PlayerAns
{
    None,
    Correct,
    Wrong
}

