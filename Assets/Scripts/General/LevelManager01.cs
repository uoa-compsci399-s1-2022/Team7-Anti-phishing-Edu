using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager01 : MonoBehaviour
{
    public GameObject defaultButton;
    public GameObject returnButton;
    public GameObject videoPanel;
    public GameObject tips;

    private void Start()
    {
        defaultButton.SetActive(false);
        returnButton.SetActive(false);
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(5.0f);
        defaultButton.SetActive(true);
    }

    public void OnButtonClicked()
    {
        videoPanel.SetActive(false);
        tips.SetActive(true);
        defaultButton.SetActive(false);
        returnButton.SetActive(true);
    }
}
