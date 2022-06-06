using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class LevelManager01 : MonoBehaviour
{
    public GameObject defaultButton;
    public GameObject returnButton;
    public GameObject videoPanel;
    public GameObject tips;

    public string fileName;
    public VideoPlayer videoPlayer;

    private void Start()
    {
        defaultButton.SetActive(false);
        returnButton.SetActive(false);
        StartCoroutine(Delay());

        videoPlayer.url = Application.streamingAssetsPath + "/" + fileName;
        //Debug.Log(Application.streamingAssetsPath + "/" + fileName);
        videoPlayer.Play();
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
