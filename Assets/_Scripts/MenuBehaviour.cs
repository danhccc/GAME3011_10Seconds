using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    private int currentlLevelIndex;

    private void Start()
    {
        currentlLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void OnResumePressed()
    {
        TimerManager.Instance.Pause();
    }

    public void OnMainMenuPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void OnRetryPressed()
    {
        SceneManager.LoadScene(currentlLevelIndex);
    }

    public void OnNextLevelPressed()
    {
        SceneManager.LoadScene(currentlLevelIndex + 1);
    }
}

