using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailDetailDataManager : MonoBehaviour
{
    private GameManager gameManager;
    private InboxEmailDataManager inboxEmailDataManager;

    private EmailScriptableObject currentEmailItemData;

    [Header("UI Part")]
    public Image senderIcon;
    public Text senderName;
    public Text senderEmailAddress;
    public Text emailTitle;
    public Text emailContent;
    public Text date;

    public Button trueButton;
    public Button falseButton;

    public GameObject feedbacks;
    public GameObject normalTrue;
    public GameObject normalFalse;
    public GameObject phishingTrue;
    public GameObject phishingFalse;

    [SerializeField]
    public EmailScriptableObject emailData;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        currentEmailItemData = gameManager.GetCurrentEmailItemData();

        senderIcon = GameObject.Find("Sender Icon").GetComponent<Image>();
        senderName = GameObject.Find("Sender Name").GetComponent<Text>();
        emailTitle = GameObject.Find("Email Title").GetComponent<Text>();
        emailContent = GameObject.Find("Email Content").GetComponent<Text>();
        senderEmailAddress = GameObject.Find("Sender Email Address").GetComponent<Text>();
        date = GameObject.Find("Date").GetComponent<Text>();

        trueButton = GameObject.Find("True Button").GetComponent<Button>();
        falseButton = GameObject.Find("False Button").GetComponent<Button>();

        feedbacks = GameObject.Find("Feedbacks");
        normalTrue = GameObject.Find("Normal Correct");
        normalFalse = GameObject.Find("Normal Wrong");
        phishingTrue = GameObject.Find("Phishing Correct");
        phishingFalse = GameObject.Find("Phishing Wrong");

        InitEmailDetailPageData();

    }

    public void InitEmailDetailPageData()
    {
        senderIcon.sprite = currentEmailItemData.senderIcon;
        senderName.text = currentEmailItemData.senderName;
        emailTitle.text = currentEmailItemData.emailTitle;
        emailContent.text = currentEmailItemData.emailContent;
        senderEmailAddress.text = currentEmailItemData.senderEmailAddress;
        date.text = currentEmailItemData.senderTime;
        emailData = currentEmailItemData;

        if (currentEmailItemData.hasRead)
        {
            trueButton.enabled = false;
            falseButton.enabled = false;
        }

        feedbacks.SetActive(false);
        normalTrue.SetActive(false);
        normalFalse.SetActive(false);
        phishingTrue.SetActive(false);
        phishingFalse.SetActive(false);
    }

    public void FalseButtonCheck()
    {
        feedbacks.SetActive(true);

        if(currentEmailItemData.emailType == EmailType.NORMAL)
        {
            // This email is a nomarl email, show the result to player. 
            gameManager.SetCurrentScore(-10);

            normalFalse.SetActive(true);
        }
        else if(currentEmailItemData.emailType == EmailType.PHISHING)
        {
            gameManager.SetCurrentScore(10);

            phishingTrue.SetActive(true);
        }

        currentEmailItemData.hasRead = true;
        gameManager.level_1_data[currentEmailItemData.itemIndex].hasRead = true;
    }

    public void TrueButtonCheck()
    {

        feedbacks.SetActive(true);

        if (currentEmailItemData.emailType == EmailType.NORMAL)
        {
            // Player make a correct dicision. 
            gameManager.SetCurrentScore(10);
            normalTrue.SetActive(true);
        }
        else if (currentEmailItemData.emailType == EmailType.PHISHING)
        {
            gameManager.SetCurrentScore(-10);
            phishingFalse.SetActive(true);
        }

        currentEmailItemData.hasRead = true;
        gameManager.level_1_data[currentEmailItemData.itemIndex].hasRead = true;
    }

}
