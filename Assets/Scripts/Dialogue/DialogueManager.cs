using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Queue<DialogueScentenceData> dialogueScentences = new Queue<DialogueScentenceData>();
    private Queue<DialogueScentenceData> dialogueChoiceSentences = new Queue<DialogueScentenceData>();

    //UI Part
    [Header("UI Part")]
    public Text dialogueContent;
    public Text characterName;
    public Image characterProtroit;
    public GameObject nextSentenceIcon;
    public GameObject choicePanel;
    public GameObject transmissionPanel;
    public Image background;
    public Text choiceText_1;
    public Text choiceText_2;
    public Text choiceText_3;

    [Header("DATA Part")]
    public float sentenceDisplaySpeed = 0.02f;
    public Sprite office;

    public Animator dialogueBoxAnimator;

    private bool isDisplaying = false;
    private string contentCache = "";
    private DialogueScentenceData currentSentence;


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
            currentSentence = sentence;
            UpdateUI(sentence);           
            dialogueScentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void ButtonPressed()
    {
        if(dialogueChoiceSentences.Count != 0)
        {
            DisplayNextChoiceDialogue(dialogueChoiceSentences);
        }
        else if(isDisplaying == false)
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
            currentSentence = sentence;

            nextSentenceIcon.SetActive(false);

            if (sentence.hasChoices == false)
            {
                // Deactive choice Panel
                choicePanel.SetActive(false);

                // Update the UI
                UpdateUI(sentence);

                // Handle UI action
                DialogueActionHandler(sentence.actionType);

                // Save the cache data
                contentCache = sentence.sentenceContent;

                // Display text one by one character
                StopAllCoroutines();
                isDisplaying = true;
                StartCoroutine(TypeSentence(sentence.sentenceContent));
            }
            else
            {
                //Active choice Panel
                choicePanel.SetActive(true);
                choiceText_1.text = sentence.choiceContent[0].choiceContent;
                choiceText_2.text = sentence.choiceContent[1].choiceContent; 
                choiceText_3.text = sentence.choiceContent[2].choiceContent; 
            }
        }
    }

    /// <summary>
    /// Handle option button events.
    /// </summary>
    public void OptionButtonPressed(int choiceID)
    {
        choicePanel.SetActive(false);

        // Get the corresponding choice data
        DialogueChoiceData choiceData = currentSentence.choiceContent[choiceID];

        if (choiceData.dialogueChoiceSentences.Count != 0)
        {
            foreach (DialogueScentenceData sentence in choiceData.dialogueChoiceSentences)
            {
                dialogueChoiceSentences.Enqueue(sentence);
            }
        }
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

    private void DisplayNextChoiceDialogue(Queue<DialogueScentenceData> choiceDialogue)
    {
        // Have displayed all sentences under choice...
        if (choiceDialogue.Count == 0)
        {
            DisplayNextSentence();
        }
        else
        {
            // Deactive choice panel
            choicePanel.SetActive(false);

            // Get the current sentence 
            DialogueScentenceData sentence = choiceDialogue.Dequeue();

            // Update UI
            UpdateUI(sentence);

            // Store the cache
            contentCache = sentence.sentenceContent;

            // Typethe words into text panel
            StopAllCoroutines();
            isDisplaying = true;
            StartCoroutine(TypeSentence(sentence.sentenceContent));
            
        }
        
    }

    public void EndDialogue()
    {
        dialogueBoxAnimator.SetTrigger("DialogueEnd");
        Debug.Log("Dialogue Finished!");
    }
    
    public void UpdateUI(DialogueScentenceData sentence)
    {
        // Update the content
        dialogueContent.text = sentence.sentenceContent;
        // Update the name 
        characterName.text = sentence.characterName;
        // Update the protrait
        if (sentence.characterPortrait != null)
        {
            characterProtroit.color = new Color(1,1,1,1);
            characterProtroit.sprite = sentence.characterPortrait;
        }
        else
        {
            characterProtroit.color = new Color(0,0,0,0); 
        }
    }

    private void DialogueActionHandler(SentenceActionType actionType)
    {
        switch (actionType)
        {
            case SentenceActionType.Shake:
                break;

            case SentenceActionType.Transmission:
                transmissionPanel.SetActive(true);
                background.sprite = office;
                background.SetNativeSize();
                break;

            case SentenceActionType.EnterTutorialScene:
                break;

            case SentenceActionType.EnterNextScene:
                string sceneName = currentSentence.sceneName;
                if (sceneName != "")
                {
                    SceneManager.LoadScene(sceneName);
                }
                break;
        }
    }

}
