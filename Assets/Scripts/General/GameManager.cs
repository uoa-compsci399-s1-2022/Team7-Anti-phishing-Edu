using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
GameManager is used to store the total num of player's correct and wrong choices.
It is used to initize the summary report. 
*/
public class GameManager : MonoBehaviour
{

    #region Data Part

    [SerializeField] private int correctNum = 0;
    [SerializeField] private int wrongNum = 0;
    [SerializeField] private int totalNum = 0;
    [SerializeField] private int score = 0;
    [SerializeField] private int totalScore = 0;

    private List<EmailScriptableObject> currentData;
    private int currentLevelIndex;
    [SerializeField] public EmailScriptableObject currentItem;

    [SerializeField] public List<EmailScriptableObject> level_1_data;
    [SerializeField] public List<EmailScriptableObject> level_2_data;

    private static GameManager gameManagerInstance;
    

    #endregion

    #region Runtime Part

    private void Awake()
    {
        //Singlton Pattern
        if(gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }
        else
        {
            if (gameManagerInstance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(this);

    }

    #endregion

    #region Function Part
    public void ChangeLevelTo(int newLevelIndex)
    {
        currentLevelIndex = newLevelIndex;
    }

    public List<EmailScriptableObject> LoadDataToManager(int levelIndex)
    {
        switch (levelIndex)
        {
            case 1:
                currentData = level_1_data;
                break;

            case 2:
                currentData = level_2_data;
                break;
        }

        return currentData;
    }


    public void ChangedToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangedToDetailScene(string sceneName, int itemIndex)
    {
        //currentItem = currentData[itemIndex];
        SceneManager.LoadScene(sceneName);
    }

    public EmailScriptableObject GetCurrentEmailItemData()
    {
        return currentItem;
    }

    public int GetCurrentScore()
    {
        return score;
    }

    public void SetCurrentScore(int amount)
    {
        int temp = score += amount;
        if (temp < 0)
            return;
        score += amount;
    }

    #endregion
}
