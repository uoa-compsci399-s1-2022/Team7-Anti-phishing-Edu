using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Queue<DialogueScentenceData> dialogueScentences = new Queue<DialogueScentenceData>();

    //UI Part
    [Header("UI Part")]
    public Text dialogueContent;
    public Text characterName;
    public GameObject nextSentenceIcon;
    public GameObject choicePanel;

    public float sentenceDisplaySpeed = 0.02f;

    public Animator dialogueBoxAnimator;

    private bool isDisplaying = false;
    private string contentCache = "";
   

    void Start()
    {
        dialogueScentences = new Queue<DialogueScentenceData>();
        nextSentenceIcon.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Conversation Started");

        dialogueScentences.Clear();
        dialogueBoxAnimator.SetTrigger("DialogueStart");
        
        foreach(DialogueScentenceData sentence in dialogue.sentences)
        {
            dialogueContent.text = sentence.sentenceContent;
            characterName.text = sentence.characterName;
            contentCache = sentence.sentenceContent;           
            dialogueScentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void ButtonPressed()
    {
        if(isDisplaying == false)
        {
            DisplayNextSentence();
        }
        else
        {
            ShowAllContent();
            nextSentenceIcon.SetActive(true);
        }
    }

    private void ShowAllContent()
    {
        StopAllCoroutines();
        dialogueContent.text = contentCache;
        isDisplaying = false;
    }

    public void DisplayNextSentence()
    {
        if(dialogueScentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if (isDisplaying == false)
        {
            DialogueScentenceData sentence = dialogueScentences.Dequeue();
            nextSentenceIcon.SetActive(false);

            if (sentence.hasChoices == false)
            {
                choicePanel.SetActive(false);
                characterName.text = sentence.characterName;
                contentCache = sentence.sentenceContent;
                StopAllCoroutines();
                isDisplaying = true;
                StartCoroutine(TypeSentence(sentence.sentenceContent));
            }
            else
            {
                choicePanel.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Handle option button events.
    /// </summary>
    public void OptionButtonPressed()
    {
        choicePanel.SetActive(false);
        DisplayNextSentence();
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueContent.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueContent.text += letter;
            yield return new WaitForSeconds(sentenceDisplaySpeed);
        }
        
        isDisplaying = false;
        nextSentenceIcon.SetActive(true);
    }

    public void EndDialogue()
    {
        dialogueBoxAnimator.SetTrigger("DialogueEnd");
        Debug.Log("Dialogue Finished!");
    }
    

}
