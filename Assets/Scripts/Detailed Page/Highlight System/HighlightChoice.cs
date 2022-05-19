using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightChoice : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject URL;

    public void OnPointerEnter(PointerEventData eventData)
    {
        URL.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        URL.SetActive(false);
    }
}
