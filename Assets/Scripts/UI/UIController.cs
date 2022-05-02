using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public Animator backgroundAnimator;
    public float transitonTime;

    public void EnterInboxLevel(int sceneIndex)
    {
        backgroundAnimator.SetTrigger("BackgroundDisappear");
        StartCoroutine(ChangeScene(sceneIndex));
    }


    public void ReturnToInbox()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator ChangeScene(int sceneIndex)
    {
        yield return new WaitForSeconds(transitonTime);
        SceneManager.LoadScene(sceneIndex);
    }

}
