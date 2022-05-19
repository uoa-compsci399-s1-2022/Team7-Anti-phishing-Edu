using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InboxEmailDataManager : EmailDataReader
{
    public GameManager gameManager;
    public GameObject inboxEmailContainer; // Place to spawn the emails
    public int levelIndex;

    public List<EmailScriptableObject> inboxEmailList;
    
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        inboxEmailList = gameManager.LoadDataToManager(levelIndex);

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
            }else if (inboxEmailItemComp.hasRead)
            {
                inboxEmailItemComp.emailIcon.sprite = inboxEmailList[index].EmailIconRead;
            }
        }
    }

}
