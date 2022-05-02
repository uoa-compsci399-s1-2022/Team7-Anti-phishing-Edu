using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightChoice : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public HighlightSystem highlightSystem;

    public bool isOnChecked;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOnChecked = true;
        gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOnChecked = false;
        gameObject.SetActive(false);
    }
}
