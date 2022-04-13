using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InboxEmailDataManager : EmailDataReader
{
    public GameManager gameManager;
    public GameObject inboxEmailContainer; // Place to spawn the emails
    public int levelIndex;

    private List<EmailScriptableObject> inboxEmailList;
    
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        inboxEmailList = gameManager.LoadDataToManager(levelIndex);

        for(int index = 0; index < inboxEmailList.Count; index++)
        {
            GameObject singleEmail = Instantiate(Resources.Load("GameObjects(Prefabs)/Email Inbox Item") as GameObject, inboxEmailContainer.transform);
            singleEmail.GetComponent<InboxEmailItem>().emailData = inboxEmailList[index];
        }
    }

}
