using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public void EnterInboxLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }


    public void ReturnToInbox()
    {
        SceneManager.LoadScene(0);
    }
}
