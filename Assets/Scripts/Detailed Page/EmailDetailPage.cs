using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailDetailPage : MonoBehaviour
{

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
        senderIcon = GameObject.Find("Sender Icon").GetComponent<Image>();
        senderName = GameObject.Find("Sender Name").GetComponent<Text>();
        emailTitle = GameObject.Find("Email Title").GetComponent<Text>();
        emailContent = GameObject.Find("Email Content").GetComponent<Text>();
        date = GameObject.Find("Date").GetComponent<Text>();
    }

    public void InitEmailDetailPageData()
    {
        
    }



}
