using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InboxEmailItem : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    private int itemIndex;

    public Image senderIcon;
    public Text senderName;
    public Text emailTitle;
    public Text emailContent;
    public Text date;

    [SerializeField]
    public EmailScriptableObject emailData;
    public GameManager gameManager;
    public string detailSceneName;

    private void Start()
    {
        itemIndex = emailData.itemIndex;

        senderIcon = GameObject.Find("Sender Icon").GetComponent<Image>();
        senderName = GameObject.Find("Sender Name").GetComponent<Text>();
        emailTitle= GameObject.Find("Email Title").GetComponent<Text>();
        emailContent = GameObject.Find("Email Content").GetComponent<Text>();
        date = GameObject.Find("Date").GetComponent<Text>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.ChangedToDetailScene(detailSceneName, itemIndex);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        UpdateInfo();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }

    /// <summary>
    /// Update UI
    /// </summary>
    private void UpdateInfo()
    {
        senderIcon.sprite = emailData.senderIcon;
        senderName.text = emailData.senderName;
        emailTitle.text = emailData.emailTitle;
        emailContent.text = emailData.emailContent;
        date.text = emailData.senderTime;
    }
}
