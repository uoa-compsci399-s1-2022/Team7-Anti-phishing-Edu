using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailDetailDataManager : MonoBehaviour
{
    private GameManager gameManager;

    private EmailScriptableObject currentEmailItemData;

    public Image senderIcon;
    public Text senderName;
    public Text senderEmailAddress;
    public Text emailTitle;
    public Text emailContent;
    public Text date;

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
    }

}
