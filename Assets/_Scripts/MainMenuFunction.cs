using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    public GameObject MenuScreen;
    public GameObject InstructionScreen;
    public GameObject CreditsScreen;


    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void OnStartPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnInstructionPressed()
    {
        CinemachineSwitcher.Instance.animator.Play("InstructionCamera");

        MenuScreen.SetActive(false);
        InstructionScreen.SetActive(true);
        CreditsScreen.SetActive(false);
    }

    public void OnCreditsPressed()
    {
        CinemachineSwitcher.Instance.animator.Play("CreditsCamera");

        MenuScreen.SetActive(false);
        InstructionScreen.SetActive(false);
        CreditsScreen.SetActive(true);
    }

    public void OnBackPressed()
    {
        CinemachineSwitcher.Instance.animator.Play("MainMenuCamera");

        MenuScreen.SetActive(true);
        InstructionScreen.SetActive(false);
        CreditsScreen.SetActive(false);
    }

    public void OnQuitPressed()
    {
        Debug.Log("Quit Pressed");
        Application.Quit();
    }
}
