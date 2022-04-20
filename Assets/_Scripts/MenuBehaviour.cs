using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    

    public void OnResumePressed()
    {
        TimerManager.Instance.Pause();
    }

    public void OnMainMenuPressed()
    {
        //SceneManager.LoadScene("");
    }

    public void OnRetryPressed()
    {
        SceneManager.LoadScene("GameScene");
    }
}

