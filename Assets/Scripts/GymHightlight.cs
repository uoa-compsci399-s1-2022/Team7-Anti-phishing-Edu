using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GymHightlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Animator highlightText;
    public GameObject knowledgePoint;

    public bool isClicked = false;


    public void OnPointerClick(PointerEventData eventData)
    {
        isClicked = true;
        knowledgePoint.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        highlightText.Play("Highlight Appear");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isClicked)
        {
            highlightText.Play("Highlight Disappear");
        }
    }
}
