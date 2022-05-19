using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("UI PART")]
    public GameObject choiceSection;
    public GameObject highlightGreen;
    public GameObject highlightRed;

    [Header("DATA PART")]
    public bool hasChecked;
    public bool correctAnswer;
    public bool currentAnswer;

    private void Start()
    {
        choiceSection.SetActive(false);
        highlightGreen.SetActive(false);
        highlightRed.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        choiceSection.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(CloseChoice());
    }

    public void TrueButtonPressed()
    {
        hasChecked = true;
        currentAnswer = true;
        highlightGreen.SetActive(true);
        highlightRed.SetActive(false);
        choiceSection.SetActive(false);
    }

    public void FalseButtonPressed()
    {
        hasChecked = true;
        currentAnswer = false;
        highlightRed.SetActive(true);
        highlightGreen.SetActive(false);
        choiceSection.SetActive(false);
    }

    IEnumerator CloseChoice()
    {
        yield return new WaitForSeconds(1.0f);
        
    }
}
