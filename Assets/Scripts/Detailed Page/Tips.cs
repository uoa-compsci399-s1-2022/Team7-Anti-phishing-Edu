using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tips : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public Animator tipsAnimator;
    public Animator tipsContentAnimator;

    public GameObject tipsContent;

    public void OnPointerClick(PointerEventData eventData)
    {
        tipsContent.SetActive(true);
        tipsContentAnimator.SetTrigger("TipsContentEnable");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tipsAnimator.SetBool("TipsActive", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tipsAnimator.SetBool("TipsActive", false);
    }

    public void CloseTipsContent()
    {
        tipsContentAnimator.SetTrigger("TipsContentDisable");
    }
}
