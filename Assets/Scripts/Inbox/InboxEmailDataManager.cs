using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InboxEmailDataManager : EmailDataReader
{
    public GameManager gameManager;
    public GameObject inboxEmailContainer; // Place to spawn the emails
    public GameObject returnButton;
    public GameObject scoreBoard;
    public GameObject scoreContainer;

    public Text accuracy;
    public Text totalScoreMarks;
    
    public int levelIndex;

    public List<EmailScriptableObject> inboxEmailList;

    [SerializeField] private bool isAllEmailChecked;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        inboxEmailList = gameManager.LoadDataToManager(levelIndex);

        scoreBoard.SetActive(false);

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
    public void OnReturnButtonPressed()
    {
        returnButton.SetActive(false);

        int totalMarks = 0;
        float correctNum = 0;

        scoreBoard.SetActive(true);

        // Show stats
        for (int index = 0; index < inboxEmailList.Count; index++)
        {
            GameObject singleEmailScore = Instantiate(Resources.Load("GameObjects(Prefabs)/Single Email Score") as GameObject, scoreContainer.transform);
            SingleEmailScore emailScore = singleEmailScore.GetComponent<SingleEmailScore>();
            emailScore.emailName.text = string.Format("Email {0}", index + 1);
            emailScore.status.text = inboxEmailList[index].playerAns == PlayerAns.Correct ? "Correct" : "Wrong";
            emailScore.score.text = inboxEmailList[index].playerAns == PlayerAns.Correct ? "+5" : "+0";

            if (inboxEmailList[index].playerAns == PlayerAns.Correct)
            {
                totalMarks += 5;
                correctNum += 1;
            }
        }
  
        totalScoreMarks.text = string.Format("Total Marks: {0}", totalMarks);

        float rate = correctNum / inboxEmailList.Count;
        accuracy.text = string.Format("In this chapter, your accuracy is {0:P}", rate);
        Debug.Log(rate);

    }
}
