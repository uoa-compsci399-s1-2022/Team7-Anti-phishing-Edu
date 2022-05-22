using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InboxEmailDataManager : EmailDataReader
{
    public GameManager gameManager;
    public GameObject inboxEmailContainer; // Place to spawn the emails
    public GameObject returnButton;
    public int levelIndex;

    public List<EmailScriptableObject> inboxEmailList;

    [SerializeField] private bool isAllEmailChecked;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        inboxEmailList = gameManager.LoadDataToManager(levelIndex);

        isAllEmailChecked = true;

        for(int index = 0; index < inboxEmailList.Count; index++)
        {
            GameObject singleEmail = Instantiate(Resources.Load("GameObjects(Prefabs)/Email Inbox Item") as GameObject, inboxEmailContainer.transform);
            InboxEmailItem inboxEmailItemComp = singleEmail.GetComponent<InboxEmailItem>();

            inboxEmailItemComp.emailData = inboxEmailList[index];
            inboxEmailItemComp.detailSceneName = inboxEmailList[index].relatedSceneName;
            inboxEmailItemComp.hasRead = inboxEmailList[index].hasRead;

            if (!inboxEmailItemComp.hasRead)
            {
                inboxEmailItemComp.emailIcon.sprite = inboxEmailList[index].EmailIconNotRead;
                inboxEmailItemComp.emailIcon.SetNativeSize();
                isAllEmailChecked = false;

            }
            else if (inboxEmailItemComp.hasRead)
            {
                Debug.Log("Item Changed!");
                inboxEmailItemComp.emailIcon.sprite = inboxEmailList[index].EmailIconRead;
                inboxEmailItemComp.emailIcon.SetNativeSize();
            }
        }

        if (isAllEmailChecked)
        {
            returnButton.SetActive(true);
        }
    }
}
