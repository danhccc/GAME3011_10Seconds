using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    public void OnStartPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnInstructionPressed()
    {

    }

    public void OnCreditsPressed()
    {

    }

    public void OnBackPressed()
    {

    }
}
