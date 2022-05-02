using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightSystemManager : MonoBehaviour
{
    [Header("DATA PART")]
    public List<HighlightSystem> highlightItems;

    [Header("UI PART")]
    public GameObject popUpPanel;

    private int correctNum;
    private int wrongNum;

    private void Start()
    {
        highlightItems = new List<HighlightSystem>();
    }

    public void OnSendButtonPressed()
    {
        foreach (HighlightSystem item in highlightItems)
        {
            if(item.correctAnswer == item.currentAnswer)
            {
                correctNum += 1;
            }
            else
            {
                wrongNum += 1;
            }
        }
    }

}
